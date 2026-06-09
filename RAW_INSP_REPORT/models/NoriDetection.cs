using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace NDS.Report.Models
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("t_nori_detection")]
    public class NoriDetection
    {
        
     
        /// <summary>
        /// 备  注:指标编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="indicator_id" ,IsPrimaryKey = true) ]
        public int IndicatorId  { get; set;  } 
     
        /// <summary>
        /// 备  注:文本型结果
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="data_string" ) ]
        public string? DataString  { get; set;  } 
     
        /// <summary>
        /// 备  注:数值型结果
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="data_num" ) ]
        public decimal? DataNum  { get; set;  } 
     
        /// <summary>
        /// 备  注:Y 检测完成 ; N 未检测;  I 不检测
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="detection_result" ) ]
        public string DetectionResult  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:图片
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="data_pic" ) ]
        public Byte[]? DataPic  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="data_bool" ) ]
        public bool? DataBool  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="suggestion_text" ) ]
        public string? SuggestionText  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="create_date" ) ]
        public DateTime? CreateDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:选择型结果
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="data_item" ) ]
        public int? DataItem  { get; set;  } 
     
        /// <summary>
        /// 备  注:检测日期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="detection_date" ) ]
        public DateTime? DetectionDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="nori_id" ,IsPrimaryKey = true) ]
        public Guid NoriId  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="user_id" ) ]
        public Guid? UserId  { get; set;  }

        [Navigate(NavigateType.OneToOne, nameof(DataItem))]
        public ComboItems? ComboItemInfo { get; set; }
    

    }
    
}