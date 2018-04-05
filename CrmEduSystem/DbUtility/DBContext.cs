using MvcPager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbUtility
{
    public sealed class DBContext
    {
        /// <summary>
        /// 数据库实例
        /// </summary>
        private DbProviderFactory _ProviderFactory;


        private string _ConnectionString;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _ConnectionString; }

        }


        private IList<DbParameter> _DbParameters;
        /// <summary>
        /// sql参数集合
        /// </summary>
        public IList<DbParameter> DbParameters
        {
            get { return _DbParameters; }
            set { _DbParameters = value; }
        }

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public DBContext()
            : this(System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString(), new List<DbParameter>(), DbProviderType.SqlServer)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        public DBContext(string connectionString)
            : this(connectionString, new List<DbParameter>(), DbProviderType.SqlServer)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="dbproviderType">数据库类型枚举</param>
        public DBContext(string connectionString, DbProviderType dbproviderType)
            : this(connectionString, new List<DbParameter>(), dbproviderType)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="providerType">数据库类型枚举</param>
        public DBContext(string connectionString, IList<DbParameter> parameters, DbProviderType providerType)
        {
            _ConnectionString = connectionString;

            _ProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            //_ProviderFactory = DbProviderFactories.GetFactory("System.Data.SQLite");

            _DbParameters = new List<DbParameter>();

            if (_ProviderFactory == null)
            {
                throw new ArgumentException("数据库工厂类中没有提供输入的数据库类型!");
            }
        }

        #endregion

        #region 增删改

        /// <summary>   
        /// 对数据库执行增删改操作，返回受影响的行数。   
        /// </summary>   
        /// <param name="sql">要执行的增删改的SQL语句</param>   
        /// <returns></returns>  
        public int ExecuteNonQuerySql(string sql)
        {
            return ExecuteNonQuery(sql, DbParameters, CommandType.Text);
        }

        /// <summary>   
        /// 对数据库执行增删改操作，返回受影响的行数。   
        /// </summary>   
        /// <param name="sql">要执行的增删改的SQL语句</param>   
        /// <param name="parameters">执行增删改语句所需要的参数</param>
        /// <returns></returns>  
        public int ExecuteNonQuerySql(string sql, IList<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.Text);
        }

        /// <summary>   
        /// 对数据库执行增删改操作，返回受影响的行数。   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <returns></returns>  
        public int ExecuteNonQueryProc(string sql)
        {
            return ExecuteNonQuery(sql, DbParameters, CommandType.StoredProcedure);
        }

        /// <summary>   
        /// 对数据库执行增删改操作，返回受影响的行数。   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <param name="parameters">执行增删改语句所需要的参数</param>
        /// <returns></returns>  
        public int ExecuteNonQueryProc(string sql, IList<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.StoredProcedure);
        }

        /// <summary>   
        /// 对数据库执行增删改操作，返回受影响的行数。   
        /// </summary>   
        /// <param name="sql">要执行的增删改的SQL语句</param>   
        /// <param name="parameters">执行增删改语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        private int ExecuteNonQuery(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            int affectedRows = 0;

            if (string.IsNullOrEmpty(sql))
            {
                return 0;
            }

            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                using (DbTransaction dbTrans = command.Connection.BeginTransaction())
                {
                    command.Transaction = dbTrans;
                    try
                    {
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch
                    {
                        dbTrans.Rollback();
                    }
                    dbTrans.Commit();
                }
                command.Parameters.Clear();
                command.Connection.Close();
            }
            return affectedRows;
        }

        #endregion

        #region 返回DataTable

        /// <summary>   
        /// 执行一个查询语句，返回一个包含查询结果的DataTable   
        /// </summary>   
        /// <param name="sql">要执行的查询语句</param>   
        /// <returns></returns>
        public DataTable ExecuteDataTableSql(string sql)
        {
            return ExecuteDataTableSql(sql, DbParameters);
        }

        /// <summary>   
        /// 执行一个查询语句，返回一个包含查询结果的DataTable   
        /// </summary>   
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTableSql(string sql, IList<DbParameter> parameters)
        {
            return ExecuteDataTableSql(sql, parameters, 1, int.MaxValue);
        }

        public DataTable ExecuteDataTableSql(string sql, IList<DbParameter> parameters, int? pageIndex, int? pageSize)
        {
            return ExecuteDataTable(sql, parameters, CommandType.Text, pageIndex, pageSize);
        }

        /// <summary>   
        /// 执行一个查询语句，返回一个包含查询结果的DataTable   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <returns></returns>
        public DataTable ExecuteDataTableProc(string sql)
        {
            return ExecuteDataTableProc(sql, DbParameters);
        }

        /// <summary>   
        /// 执行一个查询语句，返回一个包含查询结果的DataTable   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTableProc(string sql, IList<DbParameter> parameters)
        {
            return ExecuteDataTableProc(sql, parameters, 1, int.MaxValue);
        }
        /// <summary>   
        /// 执行一个查询语句，返回一个包含查询结果的DataTable   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTableProc(string sql, IList<DbParameter> parameters, int? pageIndex, int? pageSize)
        {
            return ExecuteDataTable(sql, parameters, CommandType.StoredProcedure, pageIndex, pageSize);
        }

        /// <summary>   
        /// 执行一个查询语句，返回一个包含查询结果的DataTable   
        /// </summary>   
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters, CommandType commandType, int? pageIndex, int? pageSize)
        {
            string orderby = "";

            DataTable data = new DataTable();

            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }

            if (sql.ToLower().IndexOf("order by") > -1 && sql.ToUpper().IndexOf("ROW_NUMBER") == -1 && sql.ToUpper().IndexOf("SELECT * FROM") > -1)
            {
                orderby = sql.Substring(sql.ToLower().IndexOf("order by"));
                sql = sql.Substring(0, sql.ToLower().IndexOf("order by"));
                sql = "SELECT TOP " + (pageSize ?? int.MaxValue) + " * FROM (SELECT ROW_NUMBER() OVER (" + orderby + ") AS RowNumber,* FROM (" + sql + ") AS SelectTemp) SelectTempData WHERE RowNumber > " + (pageSize ?? int.MaxValue) + "*(" + (pageIndex ?? 1) + "-1) ";
            }
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                using (DbDataAdapter adapter = _ProviderFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(data);
                    data.AcceptChanges();
                }
                command.Parameters.Clear();
                command.Connection.Close();
            }
            return data;
        }

        #endregion

        #region 返回查询结果的第一行第一列

        /// <summary>   
        /// 执行一个查询语句，返回查询结果的第一行第一列   
        /// </summary>   
        /// <param name="sql">要执行的查询语句</param>   
        /// <returns></returns>   
        public Object ExecuteScalarSql(string sql)
        {
            return ExecuteScalar(sql, DbParameters, CommandType.Text);
        }

        /// <summary>   
        /// 执行一个查询语句，返回查询结果的第一行第一列   
        /// </summary>   
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <returns></returns>   
        public Object ExecuteScalarSql(string sql, IList<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.Text);
        }

        /// <summary>   
        /// 执行一个查询语句，返回查询结果的第一行第一列   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <returns></returns>   
        public Object ExecuteScalarProc(string sql)
        {
            return ExecuteScalar(sql, DbParameters, CommandType.StoredProcedure);
        }

        /// <summary>   
        /// 执行一个查询语句，返回查询结果的第一行第一列   
        /// </summary>   
        /// <param name="sql">要执行的存储过程</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <returns></returns>   
        public Object ExecuteScalarProc(string sql, IList<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.StoredProcedure);
        }

        /// <summary>   
        /// 执行一个查询语句，返回查询结果的第一行第一列   
        /// </summary>   
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>   
        private Object ExecuteScalar(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            object result = null;
            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }
            if (sql.ToUpper().IndexOf("COUNT") > -1 && sql.ToUpper().IndexOf("ORDER BY") > -1)
            {
                string sql1 = sql.Substring(0, sql.ToUpper().IndexOf("ORDER BY"));
                string sql2 = sql.Substring(sql.ToUpper().IndexOf("ORDER BY"));
                sql2 = sql2.Substring(sql2.LastIndexOf(")"));
                sql = sql1 + sql2;
            }
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                result = command.ExecuteScalar();
                command.Parameters.Clear();
                command.Connection.Close();
            }
            return result;
        }

        #endregion

        #region 返回实体集合

        public List<T> QueryForListSql<T>(T t) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            return QueryForListSql<T>(t, string.Empty);
        }

        public List<T> QueryForListSql<T>(T t, string where) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            return QueryForListSql<T>(t, where, string.Empty, string.Empty);
        }

        public List<T> QueryForListSql<T>(T t, string where, string order, string by) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            string result = ObjectToSearchSql<T>(t, where, order, by);

            return QueryForListSql<T>(result);
        }

        public Page<T> QueryForListSql<T>(string sql, int pageIndex, int pageSize) where T : new()
        {
            return new Page<T>(QueryForListSql<T>(sql, null, pageIndex, pageSize), pageIndex, pageSize, Convert.ToInt32(ExecuteScalar("SELECT COUNT('') FROM (" + sql + ") AS SelectTemp", null, CommandType.Text)));
        }

        public Page<T> QueryForListSql<T>(T t, int pageIndex, int pageSize) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            return QueryForListSql<T>(t, pageIndex, pageSize, string.Empty);
        }

        public Page<T> QueryForListSql<T>(T t, int pageIndex, int pageSize, string where) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            return QueryForListSql(t, pageIndex, pageSize, where, string.Empty, string.Empty);
        }

        public Page<T> QueryForListSql<T>(T t, int pageIndex, int pageSize, string where, string order, string by) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            int TotalItemCount = 0;

            string result = ObjectToSearchSql<T>(t, pageIndex, pageSize, ref  TotalItemCount, where, order, by);

            Page<T> page = new Page<T>(QueryForListSql<T>(result), pageIndex, pageSize, TotalItemCount);

            return page;
        }

        /// <summary>
        /// 查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <returns></returns>
        public List<T> QueryForListSql<T>(string sql) where T : new()
        {
            return QueryForListSql<T>(sql, DbParameters);
        }

        /// <summary>
        /// 查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public List<T> QueryForListSql<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForListSql<T>(sql, parameters, 1, int.MaxValue);
        }

        public List<T> QueryForListSql<T>(string sql, IList<DbParameter> parameters, int? pageIndex, int? pageSize) where T : new()
        {
            return QueryForList<T>(sql, parameters, CommandType.Text, pageIndex, pageSize);
        }

        /// <summary>
        /// 查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的存储过程</param>   
        /// <returns></returns>
        public List<T> QueryForListProc<T>(string sql) where T : new()
        {
            return QueryForListProc<T>(sql, DbParameters);
        }

        /// <summary>
        /// 查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的存储过程</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public List<T> QueryForListProc<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForListProc<T>(sql, parameters, 1, int.MaxValue);
        }

        public List<T> QueryForListProc<T>(string sql, IList<DbParameter> parameters, int? pageIndex, int? pageSize) where T : new()
        {
            return QueryForList<T>(sql, parameters, CommandType.StoredProcedure, pageIndex, pageSize);
        }

        /// <summary>
        /// 查询多个实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        private List<T> QueryForList<T>(string sql, IList<DbParameter> parameters, CommandType commandType) where T : new()
        {
            return QueryForList<T>(sql, parameters, commandType, 1, int.MaxValue);
        }
        /// <summary>
        ///  查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        private List<T> QueryForList<T>(string sql, IList<DbParameter> parameters, CommandType commandType, int? pageIndex, int? pageSize) where T : new()
        {
            try
            {
                DataTable dt = ExecuteDataTable(sql, parameters, commandType, pageIndex, pageSize);
                if (parameters != null) parameters.Clear();
                return EntityReader.GetEntities<T>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 返回实体

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <returns></returns>
        public T QueryForObjectSql<T>(T t) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            return QueryForObjectSql<T>(t, string.Empty);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>  
        /// <param name="where">条件如（and user=‘@user’）</param>   
        /// <returns></returns>
        public T QueryForObjectSql<T>(T t, string where) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            return QueryForObjectSql<T>(t, where, string.Empty, string.Empty);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>  
        /// <param name="where">条件如（and user=‘@user’）</param>   
        /// <param name="OrderByType">排序类型</param>   
        /// <returns></returns>
        public T QueryForObjectSql<T>(T t, string where, string order, string by) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            string result = ObjectToSearchSql<T>(t, where, order, by);

            return QueryForObjectSql<T>(result, DbParameters);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>   
        /// <returns></returns>
        public T QueryForObjectSql<T>(string sql) where T : new()
        {
            return QueryForObject<T>(sql, DbParameters, CommandType.Text);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public T QueryForObjectSql<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForObject<T>(sql, parameters, CommandType.Text);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的存储过程</param>   
        /// <returns></returns>
        public T QueryForObjectProc<T>(string sql) where T : new()
        {
            return QueryForObject<T>(sql, DbParameters, CommandType.Text);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的存储过程</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public T QueryForObjectProc<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForObject<T>(sql, parameters, CommandType.Text);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        private T QueryForObject<T>(string sql, IList<DbParameter> parameters, CommandType commandType) where T : new()
        {
            List<T> list = QueryForList<T>(sql, parameters, commandType);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return default(T);
            }
        }

        #endregion

        #region 返回添加语句

        public string ObjectToInsertSql<T>(T t) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            Type type = typeof(T);

            string tableName = type.Name;

            IList<ColumnAttribute> columns = GetColumnAttribute<T>(type, t);

            StringBuilder sb = new StringBuilder("insert into [" + tableName + "]  ");

            StringBuilder field = new StringBuilder("  (  ");

            StringBuilder value = new StringBuilder(" values  (  ");

            columns = columns.Where(o => o.IsPrimaryKey == false && o.IsFilter == false && o.Value != null).ToList();

            int columnsCount = columns.Count;

            for (int i = 0; i < columnsCount; i++)
            {
                ColumnAttribute item = columns[i];
                string parameterName = "@insert" + DbParameters.Count.ToString() + item.ColumnName;
                if (i == (columnsCount - 1))
                {
                    field.Append(" [" + item.ColumnName + "])");
                    value.Append(parameterName + ")");
                }
                else
                {
                    field.Append(" [" + item.ColumnName + "] ,");
                    value.Append(parameterName + ",");
                }
                CreateParameter(parameterName, item.Value);
            }

            return sb.Append(field.ToString()).Append(value.ToString()).ToString() + "; ";
        }

        #endregion

        #region 返回修改语句

        public string ObjectToUpdateSql<T>(T t, bool clearParameter = true) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            Type type = typeof(T);
            string tableName = type.Name;
            IList<ColumnAttribute> columns = GetColumnAttribute<T>(type, t);
            StringBuilder sb = new StringBuilder(" update [" + tableName + "]  set ");
            StringBuilder where = new StringBuilder(" where 1=1 ");
            List<string> changedList = new List<string>();
            try
            {
                var icv = type.GetProperty("ChangedList").GetValue(t, null);
                if (icv != null)
                {
                    foreach (var item in icv as List<string>)
                    {
                        changedList.Add(item.ToString());
                    }
                }
            }
            catch { }

            if (changedList != null && changedList.Count > 0)
            {
                columns = columns.Where(o => changedList.Contains(o.ColumnName) && o.IsFilter == false).ToList();
            }
            else
            {
                columns = columns.Where(o => o.IsFilter == false).ToList();
            }
            int columnsCount = columns.Count;
            if (clearParameter && DbParameters != null) DbParameters.Clear();
            for (int i = 0; i < columnsCount; i++)
            {
                ColumnAttribute item = columns[i];
                if (item == null) continue;
                if (item.Value == null)
                {
                    if (item.CanNull)
                    {
                        item.Value = DBNull.Value;
                    }
                    else
                    {
                        item.Value = "";
                    }
                }
                string parameterName = "@update" + DbParameters.Count.ToString() + item.ColumnName;

                if (item.IsPrimaryKey)
                {
                    where.Append(" and [" + item.ColumnName + "] =" + parameterName);
                }
                else if (i == (columnsCount - 1))
                {
                    sb.Append(" [" + item.ColumnName + "] = " + parameterName);
                }
                else
                {
                    sb.Append(" [" + item.ColumnName + "] = " + parameterName + " , ");
                }
                CreateParameter(parameterName, item.Value);
            }
            if (sb != null && sb.Length > 0 && sb.ToString().Substring(sb.ToString().Length - 2).Trim() == ",")
            {
                sb.Remove(sb.ToString().Length - 2, 1);
            }
            return sb.Append(where.ToString()).ToString() + "; ";
        }

        #endregion

        #region 返回删除语句

        public string ObjectToDeleteSql<T>(T t, bool clearParameter = true) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            Type type = typeof(T);
            string tableName = type.Name;
            IList<ColumnAttribute> columns = GetColumnAttribute<T>(type, t);
            StringBuilder sb = new StringBuilder(" Delete From [" + tableName + "]");
            StringBuilder where = new StringBuilder(" Where 1=1 ");
            List<string> changedList = new List<string>();
            try
            {
                var icv = type.GetProperty("ChangedList").GetValue(t, null);
                if (icv != null)
                {
                    foreach (var item in icv as List<string>)
                    {
                        changedList.Add(item.ToString());
                    }
                }
            }
            catch { }
            ColumnAttribute colID = null;
            if (changedList != null && changedList.Count > 0)
            {
                colID = columns.Where(b => b.IsPrimaryKey).FirstOrDefault();
                if (colID == null)
                {
                    columns = columns.Where(o => changedList.Contains(o.ColumnName) && o.IsFilter == false).ToList();
                }
            }
            else
            {
                columns = columns.Where(o => o.IsFilter == false).ToList();
            }
            int columnsCount = columns.Count;
            if (clearParameter && DbParameters != null) DbParameters.Clear();
            if (colID != null)
            {
                string parameterName = "@delete" + DbParameters.Count.ToString() + colID.ColumnName;

                where.Append(" and [" + colID.ColumnName + "] =" + parameterName);

                CreateParameter(parameterName, colID.Value);
            }
            else
            {
                for (int i = 0; i < columnsCount; i++)
                {
                    ColumnAttribute item = columns[i];

                    string parameterName = "@delete" + DbParameters.Count.ToString() + item.ColumnName;

                    where.Append(" and [" + item.ColumnName + "] =" + parameterName);

                    CreateParameter(parameterName, item.Value);
                }
            }
            return sb.Append(where.ToString()).ToString() + "; ";
        }

        #endregion

        #region 返回查询语句

        public string ObjectToSearchSql<T>(T t) where T : new()
        {
            return ObjectToSearchSql<T>(t, string.Empty, string.Empty, string.Empty);
        }

        public string ObjectToSearchSql<T>(T t, string where, string order, string by) where T : new()
        {
            if (t == null) throw new ArgumentNullException("t");

            Type type = typeof(T);

            string tableName = type.Name;

            IList<ColumnAttribute> columns = GetColumnAttribute<T>(type, t);

            StringBuilder sb = new StringBuilder(" select * from [" + tableName + "] where 1=1 ");

            if (!string.IsNullOrEmpty(where)) sb.Append(where);

            sb.Append(CreateWhere(t));

            sb.Append(CreateOrderBy(columns, order, by));

            return sb.ToString();

        }

        public string ObjectToSearchSql<T>(T t, int pageIndex, int pageSize, ref int TotalItemCount)
        {
            return ObjectToSearchSql<T>(t, pageIndex, pageSize, ref TotalItemCount, string.Empty, string.Empty, string.Empty);
        }

        public string ObjectToSearchSql<T>(T t, int pageIndex, int pageSize, ref int TotalItemCount, string where, string order, string by)
        {
            if (t == null) throw new ArgumentNullException("t");

            Type type = typeof(T);

            string tableName = type.Name;

            IList<ColumnAttribute> columns = GetColumnAttribute<T>(type, t);

            //总条数
            StringBuilder totalItem = new StringBuilder(" select count(ID) from [" + tableName + "] where 1=1 ");
            //每页大小、当前页、排序、表、条件
            StringBuilder returnsql = new StringBuilder(@"SELECT TOP {0} * FROM 
(SELECT ROW_NUMBER() OVER ({2}) AS ROW_NUMBER,* FROM [{3}] Where 1=1 {4}) A
WHERE ROW_NUMBER > {0}*({1}-1) ");
            StringBuilder returnwhere = new StringBuilder("");

            if (!string.IsNullOrEmpty(where))
            {
                totalItem.Append(where);

                returnwhere.Append(where);
            }

            totalItem.Append(CreateWhere(t));

            returnwhere.Append(CreateWhere(t));

            string orderby = CreateOrderBy(columns, order, by);

            TotalItemCount = Convert.ToInt32(ExecuteScalarSql(totalItem.ToString()));

            orderby = string.IsNullOrEmpty(orderby) ? " order by id" : orderby;

            return string.Format(returnsql.ToString(), pageSize, pageIndex, orderby, tableName, returnwhere);
        }

        #endregion

        #region 创建参数
        /// <summary>
        /// 直接添加DbParameters参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public void CreateParameter(string name, object value)
        {
            DbParameters.Add(CreateDbParameter(name, ParameterDirection.Input, value));
        }

        /// <summary>
        ///  直接添加DbParameters参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="parameterDirection">参数类型</param>
        /// <param name="value">值</param>
        public void CreateParameter(string name, object value, ParameterDirection parameterDirection)
        {
            DbParameters.Add(CreateDbParameter(name, parameterDirection, value));
        }

        private DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value)
        {
            DbParameter parameter = _ProviderFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            return parameter;
        }

        #endregion

        #region 过滤排序

        private string CreateOrderBy(IList<ColumnAttribute> columns, string order, string by)
        {
            if (string.IsNullOrEmpty(order) || columns == null || columns.Count() == 0) return string.Empty;

            StringBuilder returnOrderBy = new StringBuilder();
            if (!string.IsNullOrEmpty(order))
            {
                string[] arrOrder = order.Split(',');
                string c = "";
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arrOrder[i]) && columns.Where(o => o.ColumnName.ToLower() == arrOrder[i].Trim().ToLower()).Count() > 0)
                    {
                        returnOrderBy.Append(c + arrOrder[i] + " " + (string.IsNullOrEmpty(by) ? "Asc" : by.Split(',')[i]));
                        c = ",";
                    }
                }
                return " order by " + returnOrderBy.ToString();
            }
            else
                return string.Empty;

        }

        #endregion

        #region 获取Where条件

        public string CreateWhere(IList<ColumnAttribute> columns)
        {
            if (columns == null || columns.Count() == 0) return string.Empty;
            StringBuilder returnwhere = new StringBuilder();
            foreach (var item in columns)
            {
                if (item.Value == null || (item.CanNull == false && item.Value.ToString() == "0")) continue;
                string parameterName = "@select" + DbParameters.Count.ToString() + item.ColumnName;
                returnwhere.Append(" and [" + item.ColumnName + "]=" + parameterName);
                CreateParameter(parameterName, item.Value);
            }

            return returnwhere.ToString();
        }

        public string CreateWhere<T>(T t)
        {
            List<ColumnAttribute> columns = new List<ColumnAttribute>();
            List<string> changeList = new List<string>();
            var chls = t.GetType().GetProperty("ChangedList").GetValue(t, null);
            if (chls == null) return "";
            foreach (var item in chls as List<String>)
            {
                changeList.Add(item.ToString());
            }
            var pps = t.GetType().GetProperties();
            if (pps != null)
            {
                foreach (var item in pps)
                {
                    try
                    {
                        var cl = item.GetCustomAttributes(false)[0] as ColumnAttribute;
                        if (cl != null)
                        {
                            cl.Value = t.GetType().GetProperty(cl.ColumnName).GetValue(t, null);
                            columns.Add(cl);
                        }
                    }
                    catch { }
                }
            }

            try
            {
                columns = columns.Where(b => b.IsFilter == false && changeList.Contains(b.ColumnName) && b.Value != null).ToList();
                StringBuilder returnwhere = new StringBuilder();
                foreach (var item in columns)
                {
                    string parameterName = "@select" + DbParameters.Count.ToString() + item.ColumnName;
                    returnwhere.Append(" and [" + item.ColumnName + "]=" + parameterName);
                    CreateParameter(parameterName, item.Value);
                }
                return returnwhere.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// 创建一个DbCommand对象
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        private DbCommand CreateDbCommand(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbConnection connection = _ProviderFactory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            DbCommand command = _ProviderFactory.CreateCommand();
            command.Connection = connection;
            command.CommandText = sql;
            command.CommandType = commandType;

            if (!(parameters == null || parameters.Count == 0))
            {
                command.Parameters.Clear();
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// 获取该类型中属性的自定义特性列表
        /// </summary>
        /// <param name="type"></param>
        public List<ColumnAttribute> GetColumnAttribute<T>(Type type, T t)
        {
            List<ColumnAttribute> propertyColumnMapping = new List<ColumnAttribute>();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo p in properties)
            {
                Attribute[] attibutes = Attribute.GetCustomAttributes(p);

                ColumnAttribute cna = null;

                foreach (Attribute attribute in attibutes)
                {
                    //检查是否设置了ColumnName属性
                    if (attribute.GetType() == typeof(ColumnAttribute))
                    {
                        cna = ((ColumnAttribute)attribute);
                        break;
                    }
                }
                if (cna == null)
                {
                    cna = new ColumnAttribute(p.Name, true, false, false);
                }

                cna.Value = EntityReader.GetValueFromObject(p.GetValue(t, null), p.PropertyType);

                propertyColumnMapping.Add(cna);
            }

            return propertyColumnMapping;

        }

        /// <summary>
        /// 获取表列名和类型
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetColumns(string tableName, string xtype)
        {
            string sqlStrColumn = @"SELECT 
                                    A.COLORDER [ColumnSort],
                                    A.NAME [Column],
                                    CASE WHEN COLUMNPROPERTY( A.ID,A.NAME,'ISIDENTITY')=1 THEN 1 ELSE 0 END IsMark,
                                    CASE WHEN EXISTS(SELECT 1 FROM SYSOBJECTS WHERE XTYPE='PK' AND PARENT_OBJ=A.ID AND NAME IN (
                                    SELECT NAME FROM SYSINDEXES WHERE INDID IN(
                                    SELECT INDID FROM SYSINDEXKEYS WHERE ID = A.ID AND COLID=A.COLID))) THEN 1 ELSE 0 END IsKey,
                                    B.NAME [Type],
                                    A.LENGTH [Length],
                                    COLUMNPROPERTY(A.ID,A.NAME,'PRECISION') [Len],
                                    ISNULL(COLUMNPROPERTY(A.ID,A.NAME,'SCALE'),0) [FloatLen],
                                    CASE WHEN A.ISNULLABLE=1 THEN 1 ELSE 0 END [IsNull],
                                    ISNULL(E.TEXT,'') [DefaultValue]
                                    ,ISNULL((select top 1 [value] from sys.extended_properties where A.ID=major_id AND A.COLID=minor_id),A.Name) [ColumnMemo]
                                    FROM 
                                    SYSCOLUMNS A
                                    LEFT JOIN 
                                    SYSTYPES B 
                                    ON 
                                    A.XUSERTYPE=B.XUSERTYPE
                                    INNER JOIN 
                                    SYSOBJECTS D 
                                    ON 
                                    A.ID=D.ID  AND D.XTYPE='" + xtype + "' and D.Name='" + tableName + @"'
                                    LEFT JOIN 
                                    SYSCOMMENTS E 
                                    ON 
                                    A.CDEFAULT=E.ID
                                    ORDER BY 
                                    A.ID,A.COLORDER";
            DataTable Column = ExecuteDataTableSql(sqlStrColumn);
            return Column;
        }

        /// <summary>
        /// 获取表列名和类型
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetMap(string tableName)
        {
            DataTable data = new DataTable();

            using (DbCommand command = CreateDbCommand("select * from [" + tableName + "]", this.DbParameters, CommandType.Text))
            {
                command.Connection.Open();
                using (DbDataAdapter adapter = _ProviderFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.FillSchema(data, SchemaType.Mapped);
                    data.AcceptChanges();
                }
                command.Parameters.Clear();
                command.Connection.Close();
            }

            return data;
        }

        /// <summary>
        /// 获得表的主键
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetPKColumn(string tableName)
        {
            string columnName = ExecuteDataTableSql("exec sp_pkeys '" + tableName + "'").Rows[0]["COLUMN_NAME"].ToString();
            return columnName;
        }


        /// <summary>
        /// 获取表中字段类型及长度
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetTypeAndLength(string tableName, string columnName)
        {
            string sql = "";
            if (string.IsNullOrEmpty(tableName))
            {
                throw new Exception("表名不能为空");
            }
            sql = "SELECT  COLUMN_NAME ,DATA_TYPE ,CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + Common.Character.ReplaceSqlKey(tableName, 50) + "' ";
            if (!string.IsNullOrEmpty(columnName))
            {
                sql += " AND COLUMN_NAME='" + Common.Character.ReplaceSqlKey(columnName, 50) + "'";
            }
            return ExecuteDataTableSql(sql);
        }


        #region MVC前端传值更新模型
        /// <summary>
        /// 列举操作方法
        /// </summary>
        public enum EnumOperation
        {
            Insert,
            Update
        }
        /// <summary>
        /// MVC前端传值更新模型
        /// </summary>
        /// <param name="id">更新时的主键值</param>
        /// <param name="tableName">表名</param>
        /// <param name="collection">form表单</param>
        /// <param name="operation">更新类型</param>
        /// <returns>更新的记录数</returns>
        public int UpdateModel(int? id, string tableName, System.Web.Mvc.FormCollection collection, EnumOperation operation)
        {
            int error = 0;
            DataTable Column = GetMap(tableName.ToString());
            string sqlStr = operation + " [" + tableName + "] ";
            if (operation == EnumOperation.Insert)
            {
                string conStrColumn = "(";
                string conStrValue = " values (";
                foreach (DataColumn item in Column.Columns)
                {
                    string columnName = item.ColumnName;
                    if (collection[columnName] != null && columnName != GetPKColumn(tableName))
                    {
                        string itemValue = collection[columnName].Replace("'", "").Trim();
                        conStrColumn = conStrColumn + "[" + columnName + "] ,";
                        if (item.DataType == typeof(String) || item.DataType == typeof(DateTime) || item.DataType == typeof(TimeSpan))
                        {
                            if (string.IsNullOrEmpty(itemValue))
                            {
                                conStrValue += " null" + ",";
                            }
                            else
                            {
                                conStrValue += " '" + itemValue + "'" + " ,";
                            }
                        }
                        else if (item.DataType == typeof(Boolean))
                        {
                            if (string.IsNullOrEmpty(itemValue))
                            {
                                conStrValue += "null,";
                            }
                            else
                            {
                                if (itemValue == "True")
                                {
                                    conStrValue += " 1 ,";
                                }
                                else
                                {
                                    conStrValue += " 0 ,";
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(itemValue))
                            {
                                conStrValue += "null,";
                            }
                            else
                            {
                                conStrValue += " " + itemValue + " ,";
                            }
                        }
                    }
                }
                conStrColumn = conStrColumn.Substring(0, conStrColumn.Length - 1);
                conStrValue = conStrValue.Substring(0, conStrValue.Length - 1);
                conStrColumn += ")";
                conStrValue += ")";
                sqlStr = sqlStr + conStrColumn + conStrValue;
            }
            else if (operation == EnumOperation.Update)
            {
                if (id != null)
                {
                    string conStrColumn = "";
                    string conStrValue = "";
                    string ConStr = " set ";
                    foreach (DataColumn item in Column.Columns)
                    {
                        string columnName = item.ColumnName;
                        if (collection[columnName] != null && columnName != GetPKColumn(tableName))
                        {
                            string itemValue = collection[columnName].Replace("'", "").Trim();
                            if (string.IsNullOrEmpty(itemValue)) itemValue = "null";
                            conStrColumn = " [" + columnName + "]";
                            if (item.DataType == typeof(String) || item.DataType == typeof(DateTime) || item.DataType == typeof(TimeSpan))
                            {
                                if (string.IsNullOrEmpty(itemValue))
                                {
                                    conStrValue = " null ";
                                }
                                else
                                {
                                    conStrValue = " '" + itemValue + "' ";
                                }
                            }
                            else if (item.DataType == typeof(Boolean))
                            {
                                if (string.IsNullOrEmpty(itemValue))
                                {
                                    conStrValue = " null ";
                                }
                                else
                                {
                                    if (itemValue == "True")
                                    {
                                        conStrValue = " 1 ";
                                    }
                                    else
                                    {
                                        conStrValue = " 0 ";
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(itemValue))
                                {
                                    conStrValue = " null ";
                                }
                                else
                                {
                                    conStrValue = " " + itemValue + " ";
                                }
                            }
                            ConStr += conStrColumn + "=" + conStrValue + " ,";
                        }
                    }
                    ConStr = ConStr.Substring(0, ConStr.Length - 1);
                    string PKColumnName = GetPKColumn(tableName.ToString());
                    sqlStr += ConStr + " where [" + PKColumnName + "]=" + id;
                }
                else
                {
                    error = -1;
                }
            }
            if (error == -1)
                return error;
            else
                return ExecuteNonQuerySql(sqlStr);
        }
        #endregion

        #region 模型填充
        /// <summary>
        /// 模型填充
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T2 FillModel<T1, T2>(T1 source, T2 target) where T2 : class, new()
        {
            var type = source.GetType();
            foreach (var item in type.GetProperties())
            {
                if (target.GetType().GetProperty(item.Name) != null)
                {
                    target.GetType().GetProperty(item.Name).SetValue(target, item.GetValue(source, null), null);
                }
            }
            return target;
        }
        #endregion
        #region 获取实体对象属性值不为空的数量，用于统计对象完成百分比等
        /// <summary>
        /// 获取实体对象属性值不为空的数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int GetHasValuePropertieNum<T>(T t) where T : new()
        {
            int result = 0;
            if (t != null)
            {
                var plts = t.GetType().GetProperties();
                foreach (var item in plts)
                {
                    var type = item.PropertyType;
                    var value = item.GetValue(t, null);
                    if (type == typeof(string))
                    {
                        if (value != null && !string.IsNullOrEmpty(value.ToString()))
                        {
                            result++;
                        }
                    }
                    else if (type == typeof(DateTime) || type == typeof(DateTime?))
                    {
                        if (value != null)
                        {
                            result++;
                        }
                    }
                    else if (type == typeof(Boolean) || type == typeof(Boolean?))
                    {
                        if (value != null)
                        {
                            result++;
                        }
                    }
                    else if (type == typeof(Int32) || type == typeof(Int32?))
                    {
                        if (value != null && Convert.ToInt32(value) != 0)
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
