using System;

namespace DbUtility
{
    /// <summary>
    /// 自定义属性，用于指示如何从DataTable或者DbDataReader中读取类的属性值
    /// </summary>
    public sealed class ColumnAttribute : Attribute
    {
        /// <summary>
        /// 类属性对应的列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 类属性是否参加拼写SQL语句
        /// </summary>
        public bool IsFilter { get; set; }

        /// <summary>
        /// 类属性是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 能否为空
        /// </summary>
        public bool CanNull { get; set; }

        /// <summary>
        /// 列值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="columnName">类属性对应的列名</param>
        /// <param name="isFilter">是否过滤</param>
        /// <param name="isPrimaryKey">是否是主键</param>
        /// <param name="canNull">是否可为空</param>
        public ColumnAttribute(string columnName, bool isFilter, bool isPrimaryKey, bool canNull)
        {
            ColumnName = columnName;
            IsFilter = isFilter;
            IsPrimaryKey = isPrimaryKey;
            if (isPrimaryKey)
            {
                canNull = false;
            }
            CanNull = canNull;
        }
    }
}
