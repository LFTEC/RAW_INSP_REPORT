
using DevExpress.DataAccess.Json;
using Dm.util;
using Microsoft.AspNetCore.Mvc;
using SAP.Report;
using SAP.Report.controller;
using SAP.Report.dto;
using SqlSugar;
using System.Net;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var service = builder.Services;

var sap_connector = builder.Configuration.GetSection("Sap_Connector").Get<SapConnectorOptions>();
if(sap_connector == null)
    throw new Exception("Sap_Connector configuration is required.");    

service.AddHttpClient<ISapApiController, SapApiController>(client =>
{
    client.BaseAddress = new Uri(sap_connector.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
}).ConfigurePrimaryHttpMessageHandler(() => 
{ 
    return new HttpClientHandler()
    {
        Credentials = new NetworkCredential(sap_connector.Username, sap_connector.Password)
    };
});

builder.Services.AddScoped<ISqlSugarClient>(s =>
{
    var db = new SqlSugarClient(new ConnectionConfig()
    {
        ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"),
        DbType = DbType.PostgreSQL,
        IsAutoCloseConnection = true,
        MoreSettings = new ConnMoreSettings()
        {
            PgSqlIsAutoToLower = false
        }
    });
    return db;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapGet("/raw_order_insp_report", async (ISapApiController api, HttpContext context, string number) =>
{
    if(string.IsNullOrEmpty(number))
        return Results.BadRequest("请输入采购订单号");

    JsonDataSource jsonDataSource = new JsonDataSource();
    try
    {
        var data_string = await api.GetPurchaseOrderInspectionDataAsync(number);
        jsonDataSource.JsonSource = new CustomJsonSource(data_string);
        jsonDataSource.Fill();
    }
    catch (Exception ex)
    {
        return Results.BadRequest("获取数据时发生错误：" + ex.Message);
    }

    using (var report1 = new raw_insp_report())
    {
        report1.DataSource = jsonDataSource;
        using (var stream = new MemoryStream())
        {
            report1.ExportToPdf(stream);
            var filename = $"report_{number}.pdf";
            var encodeFilename = Uri.EscapeDataString(filename);
            context.Response.Headers.ContentDisposition = $"inline; filename=\"{encodeFilename}\"; filename*=UTF-8''{encodeFilename}";
            return Results.File(stream.ToArray(), "application/pdf");
        }
    }
});

app.MapGet("/raw_master_insp_report", async (ISapApiController api, HttpContext context, [FromBody] InspectionPlan plan) =>
{
    if(String.IsNullOrEmpty(plan?.TaskGroup) || string.IsNullOrEmpty(plan?.GroupCounter))
        return Results.BadRequest("请输入任务组和组计数器");

    JsonDataSource jsonDataSource = new JsonDataSource();
    try
    {
        var data_string = await api.GetInspectionPlanCharsAsync(plan.TaskGroup, plan.GroupCounter);
        var data = System.Text.Json.Nodes.JsonNode.Parse(data_string!);
        if (data == null)
            return Results.BadRequest("未获取到检验计划的信息");

        var inspChars = data["inspChars"].Deserialize<List<InspectionCharacteristic>>(options: new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) ?? new List<InspectionCharacteristic>();

        if (plan.InspChars == null)
            plan.InspChars = new List<InspectionCharacteristic>();
        plan.InspChars.AddRange(inspChars);
        var planString = JsonSerializer.Serialize(plan);

        jsonDataSource.JsonSource = new CustomJsonSource(planString);
        jsonDataSource.Fill();
    }
    catch (Exception ex)
    {
        return Results.BadRequest("获取数据时发生错误：" + ex.Message);
    }

    using (var report1 = new raw_insp_master_report())
    {
        report1.DataSource = jsonDataSource;
        using (var stream = new MemoryStream())
        {
            report1.ExportToPdf(stream);
            var filename = $"report_{plan.TaskGroup}_{plan.GroupCounter}.pdf";
            var encodeFilename = Uri.EscapeDataString(filename);
            context.Response.Headers.ContentDisposition = $"inline; filename=\"{encodeFilename}\"; filename*=UTF-8''{encodeFilename}";
            return Results.File(stream.ToArray(), "application/pdf");
        }
    }
});

app.Run();


record SapConnectorOptions(string BaseUrl, string Username, string Password);
