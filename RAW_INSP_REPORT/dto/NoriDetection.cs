using SqlSugar;

namespace NDS.Report.DTO
{
    public class NoriDetection
    {
        /// <summary>
        /// 备  注:指标编号
        /// 默认值:
        ///</summary>
        public int IndicatorId { get; set; }

        public string? Value { get; set; }

        /// <summary>
        /// 备  注:Y 检测完成 ; N 未检测;  I 不检测
        /// 默认值:
        ///</summary>
        public string DetectionResult { get; set; } = null!;


        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public string? SuggestionText { get; set; }

        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 备  注:检测日期
        /// 默认值:
        ///</summary>
        public DateTime? DetectionDate { get; set; }


        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        public Guid? UserId { get; set; }


        /// <summary>
        /// 备  注:指标名称
        /// 默认值:
        ///</summary>
        public string IndicatorName { get; set; } = null!;

        /// <summary>
        /// 备  注:顺序号
        /// 默认值:
        ///</summary>
        public int SerialNo { get; set; }


        /// <summary>
        /// 备  注:指标类型 T:文本型 C:选择型 I:整数型 D:浮点型 B:bool型 P:picture - 取消图片型
        /// 默认值:
        ///</summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// 备  注:阈值下限
        /// 默认值:
        ///</summary>
        public string? ThresholdLow { get; set; }

        /// <summary>
        /// 备  注:阈值上限
        /// 默认值:
        ///</summary>
        public string? ThresholdHigh { get; set; }

        /// <summary>
        /// 备  注:单位
        /// 默认值:
        ///</summary>
        public string Unit { get; set; } = null!;

        /// <summary>
        /// 备  注:选择类的主键
        /// 默认值:
        ///</summary>
        public int? ComboId { get; set; }
    }
}
