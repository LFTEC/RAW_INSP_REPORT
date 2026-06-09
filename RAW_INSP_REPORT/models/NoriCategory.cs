using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace NDS.Report.Models
{
    /// <summary>
    /// 紫菜检测分类项是否检测
    ///</summary>
    [SugarTable("t_nori_category")]
    public class NoriCategory
    {
        
     
        /// <summary>
        /// 备  注:紫菜编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="nori_id" ,IsPrimaryKey = true) ]
        public Guid NoriId  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="noDetection" ) ]
        public bool NoDetection  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="category_id" ,IsPrimaryKey = true) ]
        public int CategoryId  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="picture_data" ) ]
        public Byte[]? PictureData  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="file_name" ) ]
        public string? FileName  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="mimetype" ) ]
        public string? Mimetype  { get; set;  }

        [Navigate(NavigateType.OneToOne, nameof(CategoryId))]
        public required DetectionCategory CategoryInfo { get; set; }
    }
    
}