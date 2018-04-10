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
    public partial class Article:INotifyPropertyChanged
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
        ///SNo
        /// </summary>
        private String _SNo;
        /// <summary>
        ///SNo
        /// </summary>
        [ColumnAttribute("SNo", false, false, false)]
        public String SNo { get { return _SNo;} set{_SNo = value;OnPropertyChanged("SNo");} } 


        /// <summary>
        ///KID
        /// </summary>
        private Int32 _KID;
        /// <summary>
        ///KID
        /// </summary>
        [ColumnAttribute("KID", false, false, false)]
        public Int32 KID { get { return _KID;} set{_KID = value;OnPropertyChanged("KID");} } 


        /// <summary>
        ///SortID
        /// </summary>
        private Int32? _SortID;
        /// <summary>
        ///SortID
        /// </summary>
        [ColumnAttribute("SortID", false, false, true)]
        public Int32? SortID { get { return _SortID;} set{_SortID = value;OnPropertyChanged("SortID");} } 


        /// <summary>
        ///ClassID
        /// </summary>
        private Int32? _ClassID;
        /// <summary>
        ///ClassID
        /// </summary>
        [ColumnAttribute("ClassID", false, false, true)]
        public Int32? ClassID { get { return _ClassID;} set{_ClassID = value;OnPropertyChanged("ClassID");} } 


        /// <summary>
        ///KeyWords
        /// </summary>
        private String _KeyWords;
        /// <summary>
        ///KeyWords
        /// </summary>
        [ColumnAttribute("KeyWords", false, false, true)]
        public String KeyWords { get { return _KeyWords;} set{_KeyWords = value;OnPropertyChanged("KeyWords");} } 


        /// <summary>
        ///Quote
        /// </summary>
        private String _Quote;
        /// <summary>
        ///Quote
        /// </summary>
        [ColumnAttribute("Quote", false, false, true)]
        public String Quote { get { return _Quote;} set{_Quote = value;OnPropertyChanged("Quote");} } 


        /// <summary>
        ///Title
        /// </summary>
        private String _Title;
        /// <summary>
        ///Title
        /// </summary>
        [ColumnAttribute("Title", false, false, false)]
        public String Title { get { return _Title;} set{_Title = value;OnPropertyChanged("Title");} } 


        /// <summary>
        ///Summary
        /// </summary>
        private String _Summary;
        /// <summary>
        ///Summary
        /// </summary>
        [ColumnAttribute("Summary", false, false, true)]
        public String Summary { get { return _Summary;} set{_Summary = value;OnPropertyChanged("Summary");} } 


        /// <summary>
        ///Content
        /// </summary>
        private String _Content;
        /// <summary>
        ///Content
        /// </summary>
        [ColumnAttribute("Content", false, false, true)]
        public String Content { get { return _Content;} set{_Content = value;OnPropertyChanged("Content");} } 


        /// <summary>
        ///ReadCount
        /// </summary>
        private Int32 _ReadCount;
        /// <summary>
        ///ReadCount
        /// </summary>
        [ColumnAttribute("ReadCount", false, false, false)]
        public Int32 ReadCount { get { return _ReadCount;} set{_ReadCount = value;OnPropertyChanged("ReadCount");} } 


        /// <summary>
        ///Status
        /// </summary>
        private Int32 _Status;
        /// <summary>
        ///Status
        /// </summary>
        [ColumnAttribute("Status", false, false, false)]
        public Int32 Status { get { return _Status;} set{_Status = value;OnPropertyChanged("Status");} } 


        /// <summary>
        ///ReleaseDate
        /// </summary>
        private DateTime? _ReleaseDate;
        /// <summary>
        ///ReleaseDate
        /// </summary>
        [ColumnAttribute("ReleaseDate", false, false, true)]
        public DateTime? ReleaseDate { get { return _ReleaseDate;} set{_ReleaseDate = value;OnPropertyChanged("ReleaseDate");} } 


        /// <summary>
        ///Thumbs
        /// </summary>
        private String _Thumbs;
        /// <summary>
        ///Thumbs
        /// </summary>
        [ColumnAttribute("Thumbs", false, false, true)]
        public String Thumbs { get { return _Thumbs;} set{_Thumbs = value;OnPropertyChanged("Thumbs");} } 


        /// <summary>
        ///Files
        /// </summary>
        private String _Files;
        /// <summary>
        ///Files
        /// </summary>
        [ColumnAttribute("Files", false, false, true)]
        public String Files { get { return _Files;} set{_Files = value;OnPropertyChanged("Files");} } 


        /// <summary>
        ///Remark
        /// </summary>
        private String _Remark;
        /// <summary>
        ///Remark
        /// </summary>
        [ColumnAttribute("Remark", false, false, true)]
        public String Remark { get { return _Remark;} set{_Remark = value;OnPropertyChanged("Remark");} } 


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
    public partial class ArticleLogic
    {
        /// <summary>
        /// Article数据操作对象
        /// </summary>
        private ArticleService os = new ArticleService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public ArticleLogic(DBContext obj)
        {
            os = new ArticleService(obj);
        }
        /// <summary>
        /// 添加Article
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(Article obj)
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
        /// 添加Article
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(Article obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [Article]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<Article> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (Article item in obj)
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
        /// 修改Article
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(Article obj)
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
        public bool Update(List<Article> olts)
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
        /// 根据编号删除Article，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new Article { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除Article，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(Article obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<Article>(obj);
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
        /// 删除Article集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<Article> objs)
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
        /// 根据编号删除Article，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new Article { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除Article，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(Article obj)
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
        /// 根据编号删除Article，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<Article> objs)
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
        /// 获取Article集合
        /// </summary>
        /// <returns>返回Article集合</returns>
        public List<Article> GetArticles()
        {
            List<Article> objs = os.GetObjects<Article>(new Article() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Article集合</returns>
        public List<Article> GetArticles(Article obj)
        {
            obj.IsDeleted = false;

            List<Article> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回Article集合</returns>
        public List<Article> GetArticles(Article obj, string where)
        {
            obj.IsDeleted = false;

            List<Article> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Article集合</returns>
        public List<Article> GetArticles(Article obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<Article> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回Article集合</returns>
        public List<Article> GetArticles(Article obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<Article> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回Article集合</returns>
        public PagedList<Article> GetArticles(int pageIndex, int pageCount)
        {
            PagedList<Article> objs = os.GetObjects(new Article() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Article集合</returns>
        public PagedList<Article> GetArticles(Article obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<Article> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Article集合</returns>
        public PagedList<Article> GetArticles(string sql, int pageIndex, int pageCount)
        {
            PagedList<Article> objs = os.GetObjects<Article>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回Article集合</returns>
        public PagedList<Article> GetArticles(Article obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<Article> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Article集合</returns>
        public PagedList<Article> GetArticles(Article obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Article> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取Article集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Article集合</returns>
        public PagedList<Article> GetArticles(Article obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Article> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取Article
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Article</returns>
        public Article GetArticle(Article obj)
        {
			obj.IsDeleted = false;
			
            Article entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取Article
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回Article</returns>
        public Article GetArticle(int id)
        {
            Article entity = os.GetObject(new Article { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class ArticleService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public ArticleService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}