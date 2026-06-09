using SqlSugar;

namespace NDS.Report.DTO
{
    public class NoriInfo
    {
        /// <summary>
        /// 备  注:检测样品编号
        /// 默认值:
        ///</summary>
        public Guid NoriId { get; set; }

        /// <summary>
        /// 备  注:厂家
        /// 默认值:
        ///</summary>
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// 备  注:展会日期
        /// 默认值:
        ///</summary>
        public DateTime ExhibitionDate { get; set; }

        /// <summary>
        /// 备  注:展会展台编号
        /// 默认值:
        ///</summary>
        public string ExhibitionId { get; set; } = null!;

        /// <summary>
        /// 备  注:生产日期
        /// 默认值:
        ///</summary>
        public DateTime? ProductionDate { get; set; }

        /// <summary>
        /// 备  注:海区
        /// 默认值:
        ///</summary>
        public string? Maritime { get; set; }

        /// <summary>
        /// 备  注:箱数
        /// 默认值:
        ///</summary>
        public int? BoxQuantity { get; set; }

        /// <summary>
        /// 备  注:检测批次编号
        /// 默认值:
        ///</summary>
        public string BatchNo { get; set; } = null!;

        /// <summary>
        /// 备  注:创建人
        /// 默认值:
        ///</summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 备  注:创建日期
        /// 默认值:
        ///</summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 备  注:检测开始日期
        /// 默认值:
        ///</summary>
        public DateTime? DetectionDate { get; set; }

        /// <summary>
        /// 备  注:检测完成日期
        /// 默认值:
        ///</summary>
        public DateTime? CompleteDate { get; set; }

        /// <summary>
        /// 备  注:检测等级
        /// 默认值:
        ///</summary>
        public string? Level { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public string? Summary { get; set; }

        public string? Remark { get; set; }

        public required string InspectorName { get; set; }
        public required List<NoriCategory> Categories { get; set; }
    }
}
