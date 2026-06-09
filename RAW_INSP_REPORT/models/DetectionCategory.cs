using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace NDS.Report.Models
{
    /// <summary>
    /// 检测类别
    ///</summary>
    [SugarTable("t_detection_category")]
    public class DetectionCategory
    {
        
     
        /// <summary>
        /// 备  注:类别编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="category_id" ,IsPrimaryKey = true,IsIdentity = true) ]
        public int CategoryId  { get; set;  } 
     
        /// <summary>
        /// 备  注:类别名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="category_name" ) ]
        public string CategoryName  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:顺序号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="serial_no" ) ]
        public int SerialNo  { get; set;  } 
     
        /// <summary>
        /// 备  注:是否显示
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="invisible" ) ]
        public bool Invisible  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="description" ) ]
        public string Description  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="has_pic" ) ]
        public bool HasPic  { get; set;  }

        [Navigate(NavigateType.OneToMany, nameof(DetectionIndicators.CategoryId))]
        public required List<DetectionIndicators> Indicators { get; set; }
    }
    
}