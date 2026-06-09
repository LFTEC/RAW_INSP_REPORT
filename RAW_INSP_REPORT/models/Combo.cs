using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace NDS.Report.Models
{
    /// <summary>
    /// 选择项
    ///</summary>
    [SugarTable("t_combo")]
    public class Combo
    {
        
     
        /// <summary>
        /// 备  注:选择项编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="combo_id" ,IsPrimaryKey = true,IsIdentity = true) ]
        public int ComboId  { get; set;  } 
     
        /// <summary>
        /// 备  注:选择项名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="combo_name" ) ]
        public string ComboName  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="isOption" ) ]
        public bool IsOption  { get; set;  }

        [Navigate(NavigateType.OneToMany, nameof(ComboItems.ComboId))]
        public required List<ComboItems> Items { get; set; }
    }
    
}