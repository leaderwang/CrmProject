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
    public partial class CustomPage:INotifyPropertyChanged
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
        ///Type
        /// </summary>
        private Int32? _Type;
        /// <summary>
        ///Type
        /// </summary>
        [ColumnAttribute("Type", false, false, true)]
        public Int32? Type { get { return _Type;} set{_Type = value;OnPropertyChanged("Type");} } 


        /// <summary>
        ///Controller
        /// </summary>
        private String _Controller;
        /// <summary>
        ///Controller
        /// </summary>
        [ColumnAttribute("Controller", false, false, true)]
        public String Controller { get { return _Controller;} set{_Controller = value;OnPropertyChanged("Controller");} } 


        /// <summary>
        ///Action
        /// </summary>
        private String _Action;
        /// <summary>
        ///Action
        /// </summary>
        [ColumnAttribute("Action", false, false, true)]
        public String Action { get { return _Action;} set{_Action = value;OnPropertyChanged("Action");} } 


        /// <summary>
        ///Path
        /// </summary>
        private String _Path;
        /// <summary>
        ///Path
        /// </summary>
        [ColumnAttribute("Path", false, false, true)]
        public String Path { get { return _Path;} set{_Path = value;OnPropertyChanged("Path");} } 


        /// <summary>
        ///EditContent
        /// </summary>
        private String _EditContent;
        /// <summary>
        ///EditContent
        /// </summary>
        [ColumnAttribute("EditContent", false, false, true)]
        public String EditContent { get { return _EditContent;} set{_EditContent = value;OnPropertyChanged("EditContent");} } 


        /// <summary>
        ///CreateDate
        /// </summary>
        private DateTime? _CreateDate;
        /// <summary>
        ///CreateDate
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
        ///LastUpdateDate
        /// </summary>
        private DateTime? _LastUpdateDate;
        /// <summary>
        ///LastUpdateDate
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
    public partial class CustomPageLogic
    {
        /// <summary>
        /// CustomPage数据操作对象
        /// </summary>
        private CustomPageService os = new CustomPageService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomPageLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public CustomPageLogic(DBContext obj)
        {
            os = new CustomPageService(obj);
        }
        /// <summary>
        /// 添加CustomPage
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(CustomPage obj)
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
        /// 添加CustomPage
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(CustomPage obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [CustomPage]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<CustomPage> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (CustomPage item in obj)
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
        /// 修改CustomPage
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(CustomPage obj)
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
        public bool Update(List<CustomPage> olts)
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
        /// 根据编号删除CustomPage，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new CustomPage { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除CustomPage，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(CustomPage obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<CustomPage>(obj);
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
        /// 删除CustomPage集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<CustomPage> objs)
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
        /// 根据编号删除CustomPage，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new CustomPage { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除CustomPage，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(CustomPage obj)
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
        /// 根据编号删除CustomPage，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<CustomPage> objs)
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
        /// 获取CustomPage集合
        /// </summary>
        /// <returns>返回CustomPage集合</returns>
        public List<CustomPage> GetCustomPages()
        {
            List<CustomPage> objs = os.GetObjects<CustomPage>(new CustomPage() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CustomPage集合</returns>
        public List<CustomPage> GetCustomPages(CustomPage obj)
        {
            obj.IsDeleted = false;

            List<CustomPage> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回CustomPage集合</returns>
        public List<CustomPage> GetCustomPages(CustomPage obj, string where)
        {
            obj.IsDeleted = false;

            List<CustomPage> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回CustomPage集合</returns>
        public List<CustomPage> GetCustomPages(CustomPage obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<CustomPage> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回CustomPage集合</returns>
        public List<CustomPage> GetCustomPages(CustomPage obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<CustomPage> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回CustomPage集合</returns>
        public PagedList<CustomPage> GetCustomPages(int pageIndex, int pageCount)
        {
            PagedList<CustomPage> objs = os.GetObjects(new CustomPage() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CustomPage集合</returns>
        public PagedList<CustomPage> GetCustomPages(CustomPage obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<CustomPage> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CustomPage集合</returns>
        public PagedList<CustomPage> GetCustomPages(string sql, int pageIndex, int pageCount)
        {
            PagedList<CustomPage> objs = os.GetObjects<CustomPage>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回CustomPage集合</returns>
        public PagedList<CustomPage> GetCustomPages(CustomPage obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<CustomPage> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回CustomPage集合</returns>
        public PagedList<CustomPage> GetCustomPages(CustomPage obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<CustomPage> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取CustomPage集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回CustomPage集合</returns>
        public PagedList<CustomPage> GetCustomPages(CustomPage obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<CustomPage> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取CustomPage
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CustomPage</returns>
        public CustomPage GetCustomPage(CustomPage obj)
        {
			obj.IsDeleted = false;
			
            CustomPage entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取CustomPage
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回CustomPage</returns>
        public CustomPage GetCustomPage(int id)
        {
            CustomPage entity = os.GetObject(new CustomPage { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class CustomPageService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public CustomPageService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public CustomPageService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}