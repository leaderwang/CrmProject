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
    public partial class Site:INotifyPropertyChanged
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
        ///CreateUserID
        /// </summary>
        private Int32? _CreateUserID;
        /// <summary>
        ///CreateUserID
        /// </summary>
        [ColumnAttribute("CreateUserID", false, false, true)]
        public Int32? CreateUserID { get { return _CreateUserID;} set{_CreateUserID = value;OnPropertyChanged("CreateUserID");} } 


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
        ///CreateDate
        /// </summary>
        private DateTime? _CreateDate;
        /// <summary>
        ///CreateDate
        /// </summary>
        [ColumnAttribute("CreateDate", false, false, true)]
        public DateTime? CreateDate { get { return _CreateDate;} set{_CreateDate = value;OnPropertyChanged("CreateDate");} } 


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
        ///IsDeleted
        /// </summary>
        private Boolean _IsDeleted;
        /// <summary>
        ///IsDeleted
        /// </summary>
        [ColumnAttribute("IsDeleted", false, false, false)]
        public Boolean IsDeleted { get { return _IsDeleted;} set{_IsDeleted = value;OnPropertyChanged("IsDeleted");} } 


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
        ///Url
        /// </summary>
        private String _Url;
        /// <summary>
        ///Url
        /// </summary>
        [ColumnAttribute("Url", false, false, false)]
        public String Url { get { return _Url;} set{_Url = value;OnPropertyChanged("Url");} } 


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
        ///Description
        /// </summary>
        private String _Description;
        /// <summary>
        ///Description
        /// </summary>
        [ColumnAttribute("Description", false, false, true)]
        public String Description { get { return _Description;} set{_Description = value;OnPropertyChanged("Description");} } 


        /// <summary>
        ///UploadMaxSize
        /// </summary>
        private Int32? _UploadMaxSize;
        /// <summary>
        ///UploadMaxSize
        /// </summary>
        [ColumnAttribute("UploadMaxSize", false, false, true)]
        public Int32? UploadMaxSize { get { return _UploadMaxSize;} set{_UploadMaxSize = value;OnPropertyChanged("UploadMaxSize");} } 


        /// <summary>
        ///UploadAllowExt
        /// </summary>
        private String _UploadAllowExt;
        /// <summary>
        ///UploadAllowExt
        /// </summary>
        [ColumnAttribute("UploadAllowExt", false, false, true)]
        public String UploadAllowExt { get { return _UploadAllowExt;} set{_UploadAllowExt = value;OnPropertyChanged("UploadAllowExt");} } 


        /// <summary>
        ///WatermarkEnable
        /// </summary>
        private Int32? _WatermarkEnable;
        /// <summary>
        ///WatermarkEnable
        /// </summary>
        [ColumnAttribute("WatermarkEnable", false, false, true)]
        public Int32? WatermarkEnable { get { return _WatermarkEnable;} set{_WatermarkEnable = value;OnPropertyChanged("WatermarkEnable");} } 


        /// <summary>
        ///WatermarkMinWidth
        /// </summary>
        private Int32? _WatermarkMinWidth;
        /// <summary>
        ///WatermarkMinWidth
        /// </summary>
        [ColumnAttribute("WatermarkMinWidth", false, false, true)]
        public Int32? WatermarkMinWidth { get { return _WatermarkMinWidth;} set{_WatermarkMinWidth = value;OnPropertyChanged("WatermarkMinWidth");} } 


        /// <summary>
        ///WatermarkMinHeight
        /// </summary>
        private Int32? _WatermarkMinHeight;
        /// <summary>
        ///WatermarkMinHeight
        /// </summary>
        [ColumnAttribute("WatermarkMinHeight", false, false, true)]
        public Int32? WatermarkMinHeight { get { return _WatermarkMinHeight;} set{_WatermarkMinHeight = value;OnPropertyChanged("WatermarkMinHeight");} } 


        /// <summary>
        ///WatermarkImg
        /// </summary>
        private String _WatermarkImg;
        /// <summary>
        ///WatermarkImg
        /// </summary>
        [ColumnAttribute("WatermarkImg", false, false, true)]
        public String WatermarkImg { get { return _WatermarkImg;} set{_WatermarkImg = value;OnPropertyChanged("WatermarkImg");} } 


        /// <summary>
        ///WatermarkPct
        /// </summary>
        private Int32? _WatermarkPct;
        /// <summary>
        ///WatermarkPct
        /// </summary>
        [ColumnAttribute("WatermarkPct", false, false, true)]
        public Int32? WatermarkPct { get { return _WatermarkPct;} set{_WatermarkPct = value;OnPropertyChanged("WatermarkPct");} } 


        /// <summary>
        ///WatermarkQuality
        /// </summary>
        private Int32? _WatermarkQuality;
        /// <summary>
        ///WatermarkQuality
        /// </summary>
        [ColumnAttribute("WatermarkQuality", false, false, true)]
        public Int32? WatermarkQuality { get { return _WatermarkQuality;} set{_WatermarkQuality = value;OnPropertyChanged("WatermarkQuality");} } 


        /// <summary>
        ///WatermarkPos
        /// </summary>
        private Int32? _WatermarkPos;
        /// <summary>
        ///WatermarkPos
        /// </summary>
        [ColumnAttribute("WatermarkPos", false, false, true)]
        public Int32? WatermarkPos { get { return _WatermarkPos;} set{_WatermarkPos = value;OnPropertyChanged("WatermarkPos");} } 


        /// <summary>
        ///GoogleJS
        /// </summary>
        private String _GoogleJS;
        /// <summary>
        ///GoogleJS
        /// </summary>
        [ColumnAttribute("GoogleJS", false, false, true)]
        public String GoogleJS { get { return _GoogleJS;} set{_GoogleJS = value;OnPropertyChanged("GoogleJS");} } 


        /// <summary>
        ///CopyRight
        /// </summary>
        private String _CopyRight;
        /// <summary>
        ///CopyRight
        /// </summary>
        [ColumnAttribute("CopyRight", false, false, true)]
        public String CopyRight { get { return _CopyRight;} set{_CopyRight = value;OnPropertyChanged("CopyRight");} } 


        /// <summary>
        ///IsValidePermission
        /// </summary>
        private Boolean? _IsValidePermission;
        /// <summary>
        ///IsValidePermission
        /// </summary>
        [ColumnAttribute("IsValidePermission", false, false, true)]
        public Boolean? IsValidePermission { get { return _IsValidePermission;} set{_IsValidePermission = value;OnPropertyChanged("IsValidePermission");} } 


        /// <summary>
        ///IsFromFile
        /// </summary>
        private Boolean? _IsFromFile;
        /// <summary>
        ///IsFromFile
        /// </summary>
        [ColumnAttribute("IsFromFile", false, false, true)]
        public Boolean? IsFromFile { get { return _IsFromFile;} set{_IsFromFile = value;OnPropertyChanged("IsFromFile");} } 


        /// <summary>
        ///IsDeleloper
        /// </summary>
        private Boolean? _IsDeleloper;
        /// <summary>
        ///IsDeleloper
        /// </summary>
        [ColumnAttribute("IsDeleloper", false, false, true)]
        public Boolean? IsDeleloper { get { return _IsDeleloper;} set{_IsDeleloper = value;OnPropertyChanged("IsDeleloper");} } 




    }
	#endregion
	#region 基本业务
    public partial class SiteLogic
    {
        /// <summary>
        /// Site数据操作对象
        /// </summary>
        private SiteService os = new SiteService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public SiteLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public SiteLogic(DBContext obj)
        {
            os = new SiteService(obj);
        }
        /// <summary>
        /// 添加Site
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(Site obj)
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
        /// 添加Site
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(Site obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [Site]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<Site> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (Site item in obj)
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
        /// 修改Site
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(Site obj)
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
        public bool Update(List<Site> olts)
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
        /// 根据编号删除Site，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new Site { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除Site，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(Site obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<Site>(obj);
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
        /// 删除Site集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<Site> objs)
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
        /// 根据编号删除Site，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new Site { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除Site，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(Site obj)
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
        /// 根据编号删除Site，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<Site> objs)
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
        /// 获取Site集合
        /// </summary>
        /// <returns>返回Site集合</returns>
        public List<Site> GetSites()
        {
            List<Site> objs = os.GetObjects<Site>(new Site() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Site集合</returns>
        public List<Site> GetSites(Site obj)
        {
            obj.IsDeleted = false;

            List<Site> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回Site集合</returns>
        public List<Site> GetSites(Site obj, string where)
        {
            obj.IsDeleted = false;

            List<Site> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Site集合</returns>
        public List<Site> GetSites(Site obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<Site> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回Site集合</returns>
        public List<Site> GetSites(Site obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<Site> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回Site集合</returns>
        public PagedList<Site> GetSites(int pageIndex, int pageCount)
        {
            PagedList<Site> objs = os.GetObjects(new Site() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Site集合</returns>
        public PagedList<Site> GetSites(Site obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<Site> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Site集合</returns>
        public PagedList<Site> GetSites(string sql, int pageIndex, int pageCount)
        {
            PagedList<Site> objs = os.GetObjects<Site>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回Site集合</returns>
        public PagedList<Site> GetSites(Site obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<Site> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Site集合</returns>
        public PagedList<Site> GetSites(Site obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Site> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取Site集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Site集合</returns>
        public PagedList<Site> GetSites(Site obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Site> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取Site
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Site</returns>
        public Site GetSite(Site obj)
        {
			obj.IsDeleted = false;
			
            Site entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取Site
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回Site</returns>
        public Site GetSite(int id)
        {
            Site entity = os.GetObject(new Site { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class SiteService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public SiteService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public SiteService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}