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
    public partial class CourseSchedule:INotifyPropertyChanged
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
        ///CourseID
        /// </summary>
        private Int32 _CourseID;
        /// <summary>
        ///CourseID
        /// </summary>
        [ColumnAttribute("CourseID", false, false, false)]
        public Int32 CourseID { get { return _CourseID;} set{_CourseID = value;OnPropertyChanged("CourseID");} } 


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
        ///TeachDate
        /// </summary>
        private String _TeachDate;
        /// <summary>
        ///TeachDate
        /// </summary>
        [ColumnAttribute("TeachDate", false, false, true)]
        public String TeachDate { get { return _TeachDate;} set{_TeachDate = value;OnPropertyChanged("TeachDate");} } 


        /// <summary>
        ///StartTime
        /// </summary>
        private String _StartTime;
        /// <summary>
        ///StartTime
        /// </summary>
        [ColumnAttribute("StartTime", false, false, true)]
        public String StartTime { get { return _StartTime;} set{_StartTime = value;OnPropertyChanged("StartTime");} } 


        /// <summary>
        ///EndTime
        /// </summary>
        private String _EndTime;
        /// <summary>
        ///EndTime
        /// </summary>
        [ColumnAttribute("EndTime", false, false, true)]
        public String EndTime { get { return _EndTime;} set{_EndTime = value;OnPropertyChanged("EndTime");} } 


        /// <summary>
        ///Status
        /// </summary>
        private Int32? _Status;
        /// <summary>
        ///Status
        /// </summary>
        [ColumnAttribute("Status", false, false, true)]
        public Int32? Status { get { return _Status;} set{_Status = value;OnPropertyChanged("Status");} } 


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
        private Boolean _IsDeleted;
        /// <summary>
        ///IsDeleted
        /// </summary>
        [ColumnAttribute("IsDeleted", false, false, false)]
        public Boolean IsDeleted { get { return _IsDeleted;} set{_IsDeleted = value;OnPropertyChanged("IsDeleted");} } 




    }
	#endregion
	#region 基本业务
    public partial class CourseScheduleLogic
    {
        /// <summary>
        /// CourseSchedule数据操作对象
        /// </summary>
        private CourseScheduleService os = new CourseScheduleService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public CourseScheduleLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public CourseScheduleLogic(DBContext obj)
        {
            os = new CourseScheduleService(obj);
        }
        /// <summary>
        /// 添加CourseSchedule
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(CourseSchedule obj)
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
        /// 添加CourseSchedule
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(CourseSchedule obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [CourseSchedule]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<CourseSchedule> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (CourseSchedule item in obj)
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
        /// 修改CourseSchedule
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(CourseSchedule obj)
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
        public bool Update(List<CourseSchedule> olts)
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
        /// 根据编号删除CourseSchedule，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new CourseSchedule { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除CourseSchedule，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(CourseSchedule obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<CourseSchedule>(obj);
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
        /// 删除CourseSchedule集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<CourseSchedule> objs)
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
        /// 根据编号删除CourseSchedule，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new CourseSchedule { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除CourseSchedule，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(CourseSchedule obj)
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
        /// 根据编号删除CourseSchedule，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<CourseSchedule> objs)
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
        /// 获取CourseSchedule集合
        /// </summary>
        /// <returns>返回CourseSchedule集合</returns>
        public List<CourseSchedule> GetCourseSchedules()
        {
            List<CourseSchedule> objs = os.GetObjects<CourseSchedule>(new CourseSchedule() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CourseSchedule集合</returns>
        public List<CourseSchedule> GetCourseSchedules(CourseSchedule obj)
        {
            obj.IsDeleted = false;

            List<CourseSchedule> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回CourseSchedule集合</returns>
        public List<CourseSchedule> GetCourseSchedules(CourseSchedule obj, string where)
        {
            obj.IsDeleted = false;

            List<CourseSchedule> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回CourseSchedule集合</returns>
        public List<CourseSchedule> GetCourseSchedules(CourseSchedule obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<CourseSchedule> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回CourseSchedule集合</returns>
        public List<CourseSchedule> GetCourseSchedules(CourseSchedule obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<CourseSchedule> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回CourseSchedule集合</returns>
        public PagedList<CourseSchedule> GetCourseSchedules(int pageIndex, int pageCount)
        {
            PagedList<CourseSchedule> objs = os.GetObjects(new CourseSchedule() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CourseSchedule集合</returns>
        public PagedList<CourseSchedule> GetCourseSchedules(CourseSchedule obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<CourseSchedule> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CourseSchedule集合</returns>
        public PagedList<CourseSchedule> GetCourseSchedules(string sql, int pageIndex, int pageCount)
        {
            PagedList<CourseSchedule> objs = os.GetObjects<CourseSchedule>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回CourseSchedule集合</returns>
        public PagedList<CourseSchedule> GetCourseSchedules(CourseSchedule obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<CourseSchedule> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回CourseSchedule集合</returns>
        public PagedList<CourseSchedule> GetCourseSchedules(CourseSchedule obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<CourseSchedule> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取CourseSchedule集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回CourseSchedule集合</returns>
        public PagedList<CourseSchedule> GetCourseSchedules(CourseSchedule obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<CourseSchedule> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取CourseSchedule
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回CourseSchedule</returns>
        public CourseSchedule GetCourseSchedule(CourseSchedule obj)
        {
			obj.IsDeleted = false;
			
            CourseSchedule entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取CourseSchedule
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回CourseSchedule</returns>
        public CourseSchedule GetCourseSchedule(int id)
        {
            CourseSchedule entity = os.GetObject(new CourseSchedule { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class CourseScheduleService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public CourseScheduleService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public CourseScheduleService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}