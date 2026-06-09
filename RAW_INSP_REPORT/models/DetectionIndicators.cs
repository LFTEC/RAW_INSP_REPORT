using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace NDS.Report.Models
{
    /// <summary>
    /// 检测指标
    ///</summary>
    [SugarTable("t_detection_indicators")]
    public class DetectionIndicators
    {
        
     
        /// <summary>
        /// 备  注:指标编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="indicator_id" ,IsPrimaryKey = true,IsIdentity = true) ]
        public int IndicatorId  { get; set;  } 
     
        /// <summary>
        /// 备  注:指标名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="indicator_name" ) ]
        public string IndicatorName  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:顺序号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="serial_no" ) ]
        public int SerialNo  { get; set;  } 
     
        /// <summary>
        /// 备  注:不检测
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="no_detection" ) ]
        public bool NoDetection  { get; set;  } 
     
        /// <summary>
        /// 备  注:类别编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="category_id" ) ]
        public int CategoryId  { get; set;  } 
     
        /// <summary>
        /// 备  注:指标类型 T:文本型 C:选择型 I:整数型 D:浮点型 B:bool型 P:picture - 取消图片型
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="type" ) ]
        public string Type  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:是否有阳性文本
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="has_suggestion_text" ) ]
        public bool HasSuggestionText  { get; set;  } 
     
        /// <summary>
        /// 备  注:阈值下限
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="threshold_low" ) ]
        public decimal? ThresholdLow  { get; set;  } 
     
        /// <summary>
        /// 备  注:阈值上限
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="threshold_high" ) ]
        public decimal? ThresholdHigh  { get; set;  } 
     
        /// <summary>
        /// 备  注:单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="unit" ) ]
        public string Unit  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:不正常文本
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="suggestion_text" ) ]
        public string? SuggestionText  { get; set;  } 
     
        /// <summary>
        /// 备  注:选择类的主键
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="combo_id" ) ]
        public int? ComboId  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="indicator_des" ) ]
        public string IndicatorDes  { get; set;  } = null!;

        [Navigate(NavigateType.OneToOne, nameof(ComboId))]
        public Combo? Combo { get; set; }
    }
    
}