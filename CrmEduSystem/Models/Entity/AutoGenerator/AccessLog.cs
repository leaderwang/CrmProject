﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DbUtility;
using MvcPager;

namespace Models
{
	#region 实体模型
    public partial class AccessLog:INotifyPropertyChanged
    {

		        /// <summary>
        /// 属性更改通知
        /// </summary>
        private List<string> _ChangedList = new List<string>();
        /// <summary>
        /// 属性更改通知
        /// </summary>
        [ColumnAttribute("ChangedList", true, false, true)]
        public List<string> ChangedList{get{return _ChangedList;}}
        /// <summary>
        /// 客户端通知事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propName)
        {
                if (_ChangedList == null || !_ChangedList.Contains(propName))
                {
                        _ChangedList.Add(propName);

                }
                 if(PropertyChanged != null)
                {
                        PropertyChanged(this, new PropertyChangedEventArgs(propName));

                }
        }
        /// <summary>
        ///ID
        /// </summary>
        private Int32 _ID;
        /// <summary>
        ///ID
        /// </summary>
        [ColumnAttribute("ID", false, true, false)]
        public Int32 ID { get { return _ID;} set{_ID = value;OnPropertyChanged("ID");} } 


        /// <summary>
        ///用户ID
        /// </summary>
        private Int32? _UnionID;
        /// <summary>
        ///用户ID
        /// </summary>
        [ColumnAttribute("UnionID", false, false, true)]
        public Int32? UnionID { get { return _UnionID;} set{_UnionID = value;OnPropertyChanged("UnionID");} } 


        /// <summary>
        ///用户OpenId
        /// </summary>
        private String _OpenID;
        /// <summary>
        ///用户OpenId
        /// </summary>
        [ColumnAttribute("OpenID", false, false, true)]
        public String OpenID { get { return _OpenID;} set{_OpenID = value;OnPropertyChanged("OpenID");} } 


        /// <summary>
        ///用户名
        /// </summary>
        private String _UserName;
        /// <summary>
        ///用户名
        /// </summary>
        [ColumnAttribute("UserName", false, false, true)]
        public String UserName { get { return _UserName;} set{_UserName = value;OnPropertyChanged("UserName");} } 


        /// <summary>
        ///访问位置
        /// </summary>
        private String _RouteArea;
        /// <summary>
        ///访问位置
        /// </summary>
        [ColumnAttribute("RouteArea", false, false, true)]
        public String RouteArea { get { return _RouteArea;} set{_RouteArea = value;OnPropertyChanged("RouteArea");} } 


        /// <summary>
        ///Url
        /// </summary>
        private String _Url;
        /// <summary>
        ///Url
        /// </summary>
        [ColumnAttribute("Url", false, false, true)]
        public String Url { get { return _Url;} set{_Url = value;OnPropertyChanged("Url");} } 


        /// <summary>
        ///Type
        /// </summary>
        private String _Type;
        /// <summary>
        ///Type
        /// </summary>
        [ColumnAttribute("Type", false, false, true)]
        public String Type { get { return _Type;} set{_Type = value;OnPropertyChanged("Type");} } 


        /// <summary>
        ///Description
        /// </summary>
        private String _Description;
        /// <summary>
        ///Description
        /// </summary>
        [ColumnAttribute("Description", false, false, true)]
        public String Description { get { return _Description;} set{_Description = value;OnPropertyChanged("Description");} } 


        /// <summary>
        ///登录时间
        /// </summary>
        private DateTime? _CreateDate;
        /// <summary>
        ///登录时间
        /// </summary>
        [ColumnAttribute("CreateDate", false, false, true)]
        public DateTime? CreateDate { get { return _CreateDate;} set{_CreateDate = value;OnPropertyChanged("CreateDate");} } 


        /// <summary>
        ///CreateUserID
        /// </summary>
        private Int32? _CreateUserID;
        /// <summary>
        ///CreateUserID
        /// </summary>
        [ColumnAttribute("CreateUserID", false, false, true)]
        public Int32? CreateUserID { get { return _CreateUserID;} set{_CreateUserID = value;OnPropertyChanged("CreateUserID");} } 


        /// <summary>
        ///最后修改时间
        /// </summary>
        private DateTime? _LastUpdateDate;
        /// <summary>
        ///最后修改时间
        /// </summary>
        [ColumnAttribute("LastUpdateDate", false, false, true)]
        public DateTime? LastUpdateDate { get { return _LastUpdateDate;} set{_LastUpdateDate = value;OnPropertyChanged("LastUpdateDate");} } 


        /// <summary>
        ///LastUpdateUserID
        /// </summary>
        private Int32? _LastUpdateUserID;
        /// <summary>
        ///LastUpdateUserID
        /// </summary>
        [ColumnAttribute("LastUpdateUserID", false, false, true)]
        public Int32? LastUpdateUserID { get { return _LastUpdateUserID;} set{_LastUpdateUserID = value;OnPropertyChanged("LastUpdateUserID");} } 


        /// <summary>
        ///IsDeleted
        /// </summary>
        private Boolean? _IsDeleted;
        /// <summary>
        ///IsDeleted
        /// </summary>
        [ColumnAttribute("IsDeleted", false, false, true)]
        public Boolean? IsDeleted { get { return _IsDeleted;} set{_IsDeleted = value;OnPropertyChanged("IsDeleted");} } 




    }
	#endregion
	#region 基本业务
    public partial class AccessLogLogic
    {
        /// <summary>
        /// AccessLog数据操作对象
        /// </summary>
        private AccessLogService os = new AccessLogService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessLogLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public AccessLogLogic(DBContext obj)
        {
            os = new AccessLogService(obj);
        }
        /// <summary>
        /// 添加AccessLog
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(AccessLog obj)
        {
            try
            {
				if (obj.ID > 0) throw new Exception("数据库已存在此数据");

                string result = os.Add(obj);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 添加AccessLog
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(AccessLog obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [AccessLog]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<AccessLog> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (AccessLog item in obj)
                {
                    if (item.ID == 0)
                    {
                        string sql = os.Add(item);
                        result.Add(sql);
                    }
                }

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 修改AccessLog
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(AccessLog obj)
        {
            try
            {
				if (obj.ID == 0) throw new Exception("数据库不存在当前数据");
                string result = os.Update(obj);
                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="olts"></param>
        /// <returns></returns>
        public bool Update(List<AccessLog> olts)
        {
            try
            {
                string sql = "";
                foreach (var item in olts)
                {
                    sql += os.Update(item) + " ";
                }
                return os.Save(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除AccessLog，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new AccessLog { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除AccessLog，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(AccessLog obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<AccessLog>(obj);
                if (olts != null)
                {
                    foreach (var item in olts)
                    {
                        if (item.ID > 0)
                        {
                            item.IsDeleted = true;
                            sql += os.Update(item, false) + " ";
                        }
                    }
					return os.Save(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
		/// <summary>
        /// 删除AccessLog集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<AccessLog> objs)
        {
            try
            {
                if (objs == null || objs.Count == 0) return false;

                StringBuilder sql = new StringBuilder();

                foreach (var item in objs)
                {
                    if (item.ID > 0)
                    {
                        item.IsDeleted = true;

                        string result = os.Update(item, false) + " ";

                        sql.Append(result);
                    }
                }

                return os.Save(sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		/// <summary>
        /// 根据编号删除AccessLog，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new AccessLog { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除AccessLog，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(AccessLog obj)
        {
            try
            {
			    if (obj.ID < 1) throw new Exception("数据库不存在当前数据");
                string result = os.Delete(obj, false);
                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除AccessLog，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<AccessLog> objs)
        {
            try
            {
                string result = "";
                foreach (var obj in objs)
                {
                    if (obj.ID > 0)
                    {
                        result = os.Delete(obj);
                        os.Save(result);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <returns>返回AccessLog集合</returns>
        public List<AccessLog> GetAccessLogs()
        {
            List<AccessLog> objs = os.GetObjects<AccessLog>(new AccessLog() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回AccessLog集合</returns>
        public List<AccessLog> GetAccessLogs(AccessLog obj)
        {
            obj.IsDeleted = false;

            List<AccessLog> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回AccessLog集合</returns>
        public List<AccessLog> GetAccessLogs(AccessLog obj, string where)
        {
            obj.IsDeleted = false;

            List<AccessLog> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回AccessLog集合</returns>
        public List<AccessLog> GetAccessLogs(AccessLog obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<AccessLog> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回AccessLog集合</returns>
        public List<AccessLog> GetAccessLogs(AccessLog obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<AccessLog> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回AccessLog集合</returns>
        public PagedList<AccessLog> GetAccessLogs(int pageIndex, int pageCount)
        {
            PagedList<AccessLog> objs = os.GetObjects(new AccessLog() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回AccessLog集合</returns>
        public PagedList<AccessLog> GetAccessLogs(AccessLog obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<AccessLog> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回AccessLog集合</returns>
        public PagedList<AccessLog> GetAccessLogs(string sql, int pageIndex, int pageCount)
        {
            PagedList<AccessLog> objs = os.GetObjects<AccessLog>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回AccessLog集合</returns>
        public PagedList<AccessLog> GetAccessLogs(AccessLog obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<AccessLog> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回AccessLog集合</returns>
        public PagedList<AccessLog> GetAccessLogs(AccessLog obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<AccessLog> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取AccessLog集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回AccessLog集合</returns>
        public PagedList<AccessLog> GetAccessLogs(AccessLog obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<AccessLog> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取AccessLog
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回AccessLog</returns>
        public AccessLog GetAccessLog(AccessLog obj)
        {
			obj.IsDeleted = false;
			
            AccessLog entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取AccessLog
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回AccessLog</returns>
        public AccessLog GetAccessLog(int id)
        {
            AccessLog entity = os.GetObject(new AccessLog { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class AccessLogService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public AccessLogService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public AccessLogService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}