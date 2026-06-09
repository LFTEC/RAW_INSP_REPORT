using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace NDS.Report.Models
{
    /// <summary>
    /// 选择项明细
    ///</summary>
    [SugarTable("t_combo_items")]
    public class ComboItems
    {
        
     
        /// <summary>
        /// 备  注:明细编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="item_id" ,IsPrimaryKey = true,IsIdentity = true) ]
        public int ItemId  { get; set;  } 
     
        /// <summary>
        /// 备  注:选择项
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="combo_id" ) ]
        public int ComboId  { get; set;  } 
     
        /// <summary>
        /// 备  注:选择项名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="item_name" ) ]
        public string ItemName  { get; set;  } = null!;
     
        /// <summary>
        /// 备  注:是否不合格项
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="is_abnormal" ) ]
        public bool IsAbnormal  { get; set;  } 
     
        /// <summary>
        /// 备  注:顺序号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="serial_no" ) ]
        public int SerialNo  { get; set;  } 
    

    }
    
}