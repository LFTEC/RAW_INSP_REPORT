using Dm.util;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SAP.Report.controller
{

    public interface ISapApiController
    {
        Task<string?> GetPurchaseOrderInspectionDataAsync(string purchaseOrder);

        Task<string?> GetInspectionPlanCharsAsync(string taskGroup, string groupCounter);
    }
    public class SapApiController: ISapApiController
    {
        public SapApiController(HttpClient client)
        {
            _client = client;
        }

        private readonly HttpClient _client;

        public async Task<string?> GetPurchaseOrderInspectionDataAsync(string purchaseOrder)
        {
            var data = new JsonObject { ["number"] = purchaseOrder };
            
            var content = GetPayload("API_RAW_ORDER_INSP", data);

            return await PostAsync(content);
        }

        public async Task<string?> GetInspectionPlanCharsAsync(string taskGroup, string groupCounter)
        {
            var data = new JsonObject { ["taskGroup"] = taskGroup, ["groupCounter"] = groupCounter };
            var content = GetPayload("API_RAW_MASTER_INSP", data);
            return await PostAsync(content);
        }

        private HttpContent GetPayload(string type, JsonObject data)
        {
            var commData = new CommunicationRequest()
            {
                Type = type,
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Data = data
            };

            HttpContent content = JsonContent.Create<CommunicationRequest>(commData, options: new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true } );
            return content;
        }

        private async Task<string?> PostAsync(HttpContent content)
        {
            var response = await _client.PostAsync("RESTAdapter/1622/PeripheralWarehouse", content);
            
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var resultJson = JsonNode.Parse(result);
            if (resultJson != null)
            {
                if (resultJson["state"]?.GetValue<string>() == "200")
                {
                    return resultJson["data"]?.ToJsonString();
                }
                else
                {
                    throw new Exception($"接口返回失败，原因：{resultJson["message"]}");
                }
            }
            else 
                return null;
        }
    }

    public class CommunicationRequest
    {
        public string Type { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;

        public JsonObject? Data { get; set; }
    }
}
