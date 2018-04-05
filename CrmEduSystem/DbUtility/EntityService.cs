using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using MvcPager;

namespace DbUtility
{
    /// <summary>
    /// 数据库实体对象操作父类
    /// </summary>
    public abstract class EntityService
    {

        public DBContext db;

        /// <summary>
        /// 获取添加SQL语句
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回SQL语句</returns>
        public string Add<T>(T t) where T : new()
        {
            string result = db.ObjectToInsertSql(t);
            return result;
        }

        /// <summary>
        /// 获取修改SQL语句
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>返回SQL语句</returns>
        public string Update<T>(T t, bool clearParameter = true) where T : new()
        {
            string result = db.ObjectToUpdateSql(t, clearParameter);
            return result;
        }

        /// <summary>
        /// 获取删除SQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Delete<T>(T t, bool clearParameter = true) where T : new()
        {
            var result = db.ObjectToDeleteSql(t, clearParameter);
            return result;
        }
        /// <summary>
        /// 根据SQL语句获取某个值
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public Object GetScalar(string sqlStr)
        {
            var result = db.ExecuteScalarSql(sqlStr);
            db.DbParameters.Clear();
            return result;
        }

        #region 获取单个对象

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="sql">查询SQL语句</param>
        /// <returns>返回对象</returns>
        public T GetObject<T>(string sql) where T : new()
        {
            T obj = db.QueryForObjectSql<T>(sql);
            db.DbParameters.Clear();
            return obj;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回对象</returns>
        public T GetObject<T>(T t) where T : new()
        {
            T obj = db.QueryForObjectSql<T>(t);
            db.DbParameters.Clear();
            return obj;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回对象</returns>
        public T GetObject<T>(T t, string where) where T : new()
        {
            T obj = db.QueryForObjectSql<T>(t, where);
            db.DbParameters.Clear();
            return obj;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回对象</returns>
        public T GetObject<T>(T t, string where, string order, string by) where T : new()
        {
            T obj = db.QueryForObjectSql<T>(t, where, order, by);
            db.DbParameters.Clear();
            return obj;
        }

        #endregion

        #region 获取集合

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>返回集合</returns>
        public List<T> GetObjects<T>(string sql) where T : new()
        {
            List<T> objs = db.QueryForListSql<T>(sql);
            db.DbParameters.Clear();
            return objs;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回集合</returns>
        public List<T> GetObjects<T>(T t) where T : new()
        {
            List<T> objs = db.QueryForListSql<T>(t, string.Empty);
            db.DbParameters.Clear();
            return objs;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">条件</param>
        /// <returns>返回集合</returns>
        public List<T> GetObjects<T>(T t, string where) where T : new()
        {
            List<T> objs = db.QueryForListSql<T>(t, where);
            db.DbParameters.Clear();
            return objs;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序字段</param> 
        /// <param name="orderbyType">排序类型</param> 
        /// <returns>返回集合</returns>
        public List<T> GetObjects<T>(T t, string where, string order, string by) where T : new()
        {
            List<T> objs = db.QueryForListSql<T>(t, where, order, by);
            db.DbParameters.Clear();
            return objs;
        }

        #endregion

        #region 获取分页集合
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public PagedList<T> GetObjects<T>(string sql, int pageIndex, int pageCount) where T : new()
        {
            Page<T> objs = db.QueryForListSql<T>(sql, pageIndex, pageCount);
            db.DbParameters.Clear();
            return objs.ToPagedList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回集合</returns>
        public PagedList<T> GetObjects<T>(T t, int pageIndex, int pageCount) where T : new()
        {
            Page<T> objs = db.QueryForListSql<T>(t, pageIndex, pageCount);
            db.DbParameters.Clear();
            return objs.ToPagedList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="where">条件</param>
        /// <returns>返回集合</returns>
        public PagedList<T> GetObjects<T>(T t, int pageIndex, int pageCount, string where) where T : new()
        {
            Page<T> objs = db.QueryForListSql<T>(t, pageIndex, pageCount, where);
            db.DbParameters.Clear();
            return objs.ToPagedList();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="where">条件</param>
        /// <returns>返回集合</returns>
        public PagedList<T> GetObjects<T>(T t, int pageIndex, int pageCount, string where, string order, string by) where T : new()
        {
            Page<T> objs = db.QueryForListSql<T>(t, pageIndex, pageCount, where, order, by);
            db.DbParameters.Clear();
            return objs.ToPagedList();
        }

        #endregion

        public bool Save(string sqlStr)
        {
            var result = db.ExecuteNonQuerySql(sqlStr, db.DbParameters) > 0 ? true : false;
            db.DbParameters.Clear();
            return result;
        }

        public bool Save(List<string> sqls)
        {
            if (sqls == null || sqls.Count() == 0) return true;
            StringBuilder sql = new StringBuilder();
            foreach (string item in sqls)
            {
                sql.Append(item);
            }
            sqls.Clear();
            var result = db.ExecuteNonQuerySql(sql.ToString(), db.DbParameters) > 0 ? true : false;
            db.DbParameters.Clear();
            return result;
        }
    }
}
