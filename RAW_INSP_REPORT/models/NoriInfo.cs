using NDS.Report.models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NDS.Report.Models
{
    /// <summary>
    /// 紫菜信息登记表
    ///</summary>
    [SugarTable("t_nori_info")]
    public class NoriInfo
    {
        
     
        /// <summary>
        /// 备  注:检测样品编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="nori_id" ,IsPrimaryKey = true) ]
        public Guid NoriId  { get; set;  } 
     
        /// <summary>
        /// 备  注:厂家
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="vendor" ) ]
        public string Vendor  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:展会日期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="exhibition_date" ) ]
        public DateTime ExhibitionDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:展会展台编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="exhibition_id" ) ]
        public string ExhibitionId  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:生产日期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="production_date" ) ]
        public DateTime? ProductionDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:海区
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="maritime" ) ]
        public string? Maritime  { get; set;  } 
     
        /// <summary>
        /// 备  注:箱数
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="box_quantity" ) ]
        public int? BoxQuantity  { get; set;  } 
     
        /// <summary>
        /// 备  注:检测批次编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="batch_no" ) ]
        public string BatchNo  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:创建人
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="user_id" ) ]
        public Guid UserId  { get; set;  } 
     
        /// <summary>
        /// 备  注:创建日期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="create_date" ) ]
        public DateTime CreateDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:检测开始日期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="detection_date" ) ]
        public DateTime? DetectionDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:检测完成日期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="complete_date" ) ]
        public DateTime? CompleteDate  { get; set;  } 
     
        /// <summary>
        /// 备  注:检测等级
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="level" ) ]
        public string? Level  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="summary" ) ]
        public string? Summary  { get; set;  }

        [Navigate(NavigateType.OneToMany, nameof(NoriCategory.NoriId))]
        public required List<NoriCategory> Categories { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(NoriDetection.NoriId))]
        public required List<NoriDetection> Detections { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(UserId))]
        public required Users User { get; set; }

    }
    
}