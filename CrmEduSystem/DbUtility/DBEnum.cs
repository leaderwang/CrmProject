
namespace DbUtility
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DbProviderType : byte
    {
        SqlServer,
        MySql,
        SQLite,
        Oracle,
        ODBC,
        OleDb,
        Firebird,
        PostgreSql,
        DB2,
        Informix,
        SqlServerCe
    }

    public enum DbSqlType : byte
    {
        Select,
        Insert,
        Update
    }

    public enum OrderByType
    {
        NoOrderBy = 0,
        Asc = 1,
        Desc = 2,
    }

    /// <summary>
    /// 表基本字段
    /// </summary>
    public enum BaseField
    {
        ID,
        CreateUserID,
        LastUpdateUserID,
        CreateDate,
        LastUpdateDate,
        IsDeleted,
        Sort
    }

    /// <summary>
    /// 审核状态
    /// </summary>
    public enum EnumCheck
    {
        待审核 = 1,
        审核通过 = 2,
        被驳回 = 3
    }

    /// <summary>
    /// 数据字典分类
    /// </summary>
    public enum EnumDictionaryType
    {
        审核状态 = 1,
        会议预约类型 = 2,
        部门管理 = 3,
        会议详细状态 = 4,
        页面分类 = 5,
        资料库附件类型 = 6
    }

    /// <summary>
    /// 页面分类
    /// </summary>
    public enum EnumPageType
    {
        列表页 = 35,
        表单页 = 36,
        明细页 = 37
    }

    /// <summary>
    /// 系统角色
    /// </summary>
    public enum EnumRole
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        Admin = 1,
        /// <summary>
        /// 技术支持
        /// </summary>
        Tech = 2,
        /// <summary>
        /// 普通用户
        /// </summary>
        User = 3
    }

    /// <summary>
    /// 学员状态
    /// </summary>
    public enum EnumStudentStatus
    {
        无效数据 = 1,
        有效数据 = 2,
        已邀约 = 3,
        已到访 = 4,
        已报名 = 5,
        已结业 = 6
    }

}
