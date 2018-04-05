using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DbUtility;
using MvcPager;

namespace Models
{
	#region 实体模型
    public partial class QuestionItem:INotifyPropertyChanged
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
        ///QuestionID
        /// </summary>
        private Int32 _QuestionID;
        /// <summary>
        ///QuestionID
        /// </summary>
        [ColumnAttribute("QuestionID", false, false, false)]
        public Int32 QuestionID { get { return _QuestionID;} set{_QuestionID = value;OnPropertyChanged("QuestionID");} } 


        /// <summary>
        ///Name
        /// </summary>
        private String _Name;
        /// <summary>
        ///Name
        /// </summary>
        [ColumnAttribute("Name", false, false, false)]
        public String Name { get { return _Name;} set{_Name = value;OnPropertyChanged("Name");} } 


        /// <summary>
        ///IsTrue
        /// </summary>
        private Boolean? _IsTrue;
        /// <summary>
        ///IsTrue
        /// </summary>
        [ColumnAttribute("IsTrue", false, false, true)]
        public Boolean? IsTrue { get { return _IsTrue;} set{_IsTrue = value;OnPropertyChanged("IsTrue");} } 


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


        /// <summary>
        ///Tag
        /// </summary>
        private String _Tag;
        /// <summary>
        ///Tag
        /// </summary>
        [ColumnAttribute("Tag", false, false, true)]
        public String Tag { get { return _Tag;} set{_Tag = value;OnPropertyChanged("Tag");} } 




    }
	#endregion
	#region 基本业务
    public partial class QuestionItemLogic
    {
        /// <summary>
        /// QuestionItem数据操作对象
        /// </summary>
        private QuestionItemService os = new QuestionItemService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public QuestionItemLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public QuestionItemLogic(DBContext obj)
        {
            os = new QuestionItemService(obj);
        }
        /// <summary>
        /// 添加QuestionItem
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(QuestionItem obj)
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
        /// 添加QuestionItem
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(QuestionItem obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [QuestionItem]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<QuestionItem> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (QuestionItem item in obj)
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
        /// 修改QuestionItem
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(QuestionItem obj)
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
        public bool Update(List<QuestionItem> olts)
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
        /// 根据编号删除QuestionItem，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new QuestionItem { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除QuestionItem，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(QuestionItem obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<QuestionItem>(obj);
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
        /// 删除QuestionItem集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<QuestionItem> objs)
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
        /// 根据编号删除QuestionItem，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new QuestionItem { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除QuestionItem，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(QuestionItem obj)
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
        /// 根据编号删除QuestionItem，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<QuestionItem> objs)
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
        /// 获取QuestionItem集合
        /// </summary>
        /// <returns>返回QuestionItem集合</returns>
        public List<QuestionItem> GetQuestionItems()
        {
            List<QuestionItem> objs = os.GetObjects<QuestionItem>(new QuestionItem() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回QuestionItem集合</returns>
        public List<QuestionItem> GetQuestionItems(QuestionItem obj)
        {
            obj.IsDeleted = false;

            List<QuestionItem> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回QuestionItem集合</returns>
        public List<QuestionItem> GetQuestionItems(QuestionItem obj, string where)
        {
            obj.IsDeleted = false;

            List<QuestionItem> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回QuestionItem集合</returns>
        public List<QuestionItem> GetQuestionItems(QuestionItem obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<QuestionItem> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回QuestionItem集合</returns>
        public List<QuestionItem> GetQuestionItems(QuestionItem obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<QuestionItem> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回QuestionItem集合</returns>
        public PagedList<QuestionItem> GetQuestionItems(int pageIndex, int pageCount)
        {
            PagedList<QuestionItem> objs = os.GetObjects(new QuestionItem() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回QuestionItem集合</returns>
        public PagedList<QuestionItem> GetQuestionItems(QuestionItem obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<QuestionItem> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回QuestionItem集合</returns>
        public PagedList<QuestionItem> GetQuestionItems(string sql, int pageIndex, int pageCount)
        {
            PagedList<QuestionItem> objs = os.GetObjects<QuestionItem>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回QuestionItem集合</returns>
        public PagedList<QuestionItem> GetQuestionItems(QuestionItem obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<QuestionItem> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回QuestionItem集合</returns>
        public PagedList<QuestionItem> GetQuestionItems(QuestionItem obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<QuestionItem> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取QuestionItem集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回QuestionItem集合</returns>
        public PagedList<QuestionItem> GetQuestionItems(QuestionItem obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<QuestionItem> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取QuestionItem
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回QuestionItem</returns>
        public QuestionItem GetQuestionItem(QuestionItem obj)
        {
			obj.IsDeleted = false;
			
            QuestionItem entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取QuestionItem
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回QuestionItem</returns>
        public QuestionItem GetQuestionItem(int id)
        {
            QuestionItem entity = os.GetObject(new QuestionItem { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class QuestionItemService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public QuestionItemService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public QuestionItemService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}