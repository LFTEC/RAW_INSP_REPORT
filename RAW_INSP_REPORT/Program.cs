
using Dm.util;
using Microsoft.AspNetCore.Mvc;
using NDS.Report;
using NDS.Report.Models;
using SqlSugar;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var service = builder.Services;

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


app.MapGet("/report", (ISqlSugarClient db, HttpContext context, string batchNo) =>
{
    if(string.IsNullOrEmpty(batchNo))
        return Results.BadRequest("BatchNo is required.");

    var nori = db.Queryable<NoriInfo>()
        .Where(n => n.BatchNo == batchNo)
        .Includes(n=>n.Categories.Where(c=>c.NoDetection== false).OrderBy(c=>c.CategoryInfo.SerialNo).ToList(), cate=>cate.CategoryInfo, cateInfo=>cateInfo.Indicators.Where(i=>i.NoDetection==false).OrderBy(i=>i.SerialNo).ToList())
        .Includes(n=>n.Detections, dec=>dec.ComboItemInfo)
        .Includes(n=>n.User)
        .First();
    if (nori == null) return Results.BadRequest("Batch not exists");

    var dNori = MapToDto(nori);

    using (XtraReport1 report1 = new XtraReport1())
    {
        var ds = report1.ComponentStorage.OfType<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>().FirstOrDefault();
        if (ds != null)
            ds.DataSource = dNori;
        report1.CreateDocument();
        using (var stream = new MemoryStream())
        {
            report1.ExportToPdf(stream);
            var filename = $"report_{batchNo}.pdf";
            var encodeFilename = Uri.EscapeDataString(filename);
            context.Response.Headers.ContentDisposition = $"inline; filename=\"{encodeFilename}\"; filename*=UTF-8''{encodeFilename}";
            return Results.File(stream.ToArray(), "application/pdf");
        }
    }
});

app.Run();

static NDS.Report.DTO.NoriInfo MapToDto(NoriInfo nori)
{
    var dNori = new NDS.Report.DTO.NoriInfo
    {
        NoriId = nori.NoriId,
        Vendor = nori.Vendor,
        ExhibitionDate = nori.ExhibitionDate,
        ExhibitionId = nori.ExhibitionId,
        ProductionDate = nori.ProductionDate,
        Maritime = nori.Maritime,
        BoxQuantity = nori.BoxQuantity,
        BatchNo = nori.BatchNo,
        UserId = nori.UserId,
        CreateDate = nori.CreateDate,
        DetectionDate = nori.DetectionDate,
        CompleteDate = nori.CompleteDate,
        Level = nori.Level,
        Summary = nori.Summary,
        InspectorName = nori.User.Name,
        Categories = new List<NDS.Report.DTO.NoriCategory>()
    };

    foreach (var cate in nori.Categories)
    {
        var dCate = new NDS.Report.DTO.NoriCategory
        {
            CategoryId = cate.CategoryId,
            PictureData = cate.PictureData,
            FileName = cate.FileName,
            Mimetype = cate.Mimetype,
            CategoryName = cate.CategoryInfo.CategoryName,
            SerialNo = cate.CategoryInfo.SerialNo,
            Description = cate.CategoryInfo.Description,
            SuggestText = "",
            HasPic = cate.CategoryInfo.HasPic,
            Detections = new List<NDS.Report.DTO.NoriDetection>()
        };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("检验信息：");

        foreach (var indicator in cate.CategoryInfo.Indicators)
        {
            var indData = nori.Detections.FirstOrDefault(d => d.IndicatorId == indicator.IndicatorId);
            if (indData == null) continue;
            
            var dIndicator = new NDS.Report.DTO.NoriDetection
            {
                IndicatorId = indicator.IndicatorId,
                Value = "",
                DetectionResult = indData.DetectionResult,
                SuggestionText = indData.SuggestionText,
                CreateDate = indData.CreateDate,
                DetectionDate = indData.DetectionDate,
                UserId = indData.UserId,
                IndicatorName = indicator.IndicatorName,
                SerialNo = indicator.SerialNo,
                Type = indicator.Type,
                Unit = indicator.Unit,
                ComboId = indicator.ComboId
            };

            var format = "";
            if (indicator.ThresholdLow >= (decimal)1e6)
                format = "0.##e+0";
            else
                format = "0.###";
            dIndicator.ThresholdLow = indicator.ThresholdLow?.ToString(format);

            if (indicator.ThresholdHigh >= (decimal)1e6)
                format = "0.##e+0";
            else
                format = "0.###";
            dIndicator.ThresholdHigh = indicator.ThresholdHigh?.ToString(format);

            if (dIndicator.DetectionResult == "N")
                dIndicator.Value = "未检测";
            else if(dIndicator.DetectionResult == "I")
                dIndicator.Value = "未检测";
            else
            {
                if (indicator.Type == "T")
                    dIndicator.Value = indData.DataString;
                else if(indicator.Type == "C")
                    dIndicator.Value = indData.ComboItemInfo?.ItemName;
                else if(indicator.Type == "D")
                {
                    if (indData.DataNum >= (decimal)1e6)
                        format = "0.##e+0";
                    else
                        format = "0.###";

                    dIndicator.Value = indData.DataNum?.ToString(format);

                }
                    
                else if(indicator.Type == "B")
                    dIndicator.Value = indData.DataBool == true ? "是" : "否";
            }

            if(!string.IsNullOrEmpty(indData.SuggestionText))
            {
                sb.AppendLine(indData.SuggestionText);
                sb.AppendLine();
            }

            dCate.Detections.add(dIndicator);
        }

        dCate.SuggestText = sb.ToString();


        dNori.Categories.Add(dCate);

    }

    StringBuilder sb2 = new StringBuilder();
    sb2.Clear();
    sb2.AppendLine("备注：");
    sb2.AppendLine("[1] 数据来源：https://www.cnsoc.org/");
    sb2.AppendLine("[2] 数据来源：GB/T 23597-2022 干紫菜质量通则");
    sb2.AppendLine("[3] 数据来源：GB 19643-2016 食品安全国家标准 藻类及其制品");
    sb2.AppendLine("");
    dNori.Remark = sb2.ToString();


    return dNori;
}

