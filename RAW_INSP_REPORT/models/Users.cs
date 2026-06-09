using SqlSugar;

namespace NDS.Report.models
{
    [SugarTable("t_users")]
    public class Users
    {
        /// <summary>
        /// 备  注:用户编号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "user_id", IsPrimaryKey = true)]
        public Guid UserId { get; set; }

        /// <summary>
        /// 备  注:姓名
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = null!;
    }
}
