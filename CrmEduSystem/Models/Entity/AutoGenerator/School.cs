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
    public partial class School:INotifyPropertyChanged
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
        ///教育机构ID
        /// </summary>
        private Int32 _CompanyID;
        /// <summary>
        ///教育机构ID
        /// </summary>
        [ColumnAttribute("CompanyID", false, false, false)]
        public Int32 CompanyID { get { return _CompanyID;} set{_CompanyID = value;OnPropertyChanged("CompanyID");} } 


        /// <summary>
        ///学校编号
        /// </summary>
        private String _SchoolNo;
        /// <summary>
        ///学校编号
        /// </summary>
        [ColumnAttribute("SchoolNo", false, false, false)]
        public String SchoolNo { get { return _SchoolNo;} set{_SchoolNo = value;OnPropertyChanged("SchoolNo");} } 


        /// <summary>
        ///学校名称
        /// </summary>
        private String _SchoolName;
        /// <summary>
        ///学校名称
        /// </summary>
        [ColumnAttribute("SchoolName", false, false, false)]
        public String SchoolName { get { return _SchoolName;} set{_SchoolName = value;OnPropertyChanged("SchoolName");} } 


        /// <summary>
        ///简介
        /// </summary>
        private String _Content;
        /// <summary>
        ///简介
        /// </summary>
        [ColumnAttribute("Content", false, false, true)]
        public String Content { get { return _Content;} set{_Content = value;OnPropertyChanged("Content");} } 


        /// <summary>
        ///类型
        /// </summary>
        private Int32 _Type;
        /// <summary>
        ///类型
        /// </summary>
        [ColumnAttribute("Type", false, false, false)]
        public Int32 Type { get { return _Type;} set{_Type = value;OnPropertyChanged("Type");} } 


        /// <summary>
        ///状态
        /// </summary>
        private Int32 _Status;
        /// <summary>
        ///状态
        /// </summary>
        [ColumnAttribute("Status", false, false, false)]
        public Int32 Status { get { return _Status;} set{_Status = value;OnPropertyChanged("Status");} } 


        /// <summary>
        ///备注
        /// </summary>
        private String _Remark;
        /// <summary>
        ///备注
        /// </summary>
        [ColumnAttribute("Remark", false, false, false)]
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
    public partial class SchoolLogic
    {
        /// <summary>
        /// School数据操作对象
        /// </summary>
        private SchoolService os = new SchoolService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public SchoolLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public SchoolLogic(DBContext obj)
        {
            os = new SchoolService(obj);
        }
        /// <summary>
        /// 添加School
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(School obj)
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
        /// 添加School
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(School obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [School]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<School> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (School item in obj)
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
        /// 修改School
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(School obj)
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
        public bool Update(List<School> olts)
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
        /// 根据编号删除School，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new School { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除School，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(School obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<School>(obj);
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
        /// 删除School集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<School> objs)
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
        /// 根据编号删除School，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new School { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除School，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(School obj)
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
        /// 根据编号删除School，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<School> objs)
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
        /// 获取School集合
        /// </summary>
        /// <returns>返回School集合</returns>
        public List<School> GetSchools()
        {
            List<School> objs = os.GetObjects<School>(new School() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回School集合</returns>
        public List<School> GetSchools(School obj)
        {
            obj.IsDeleted = false;

            List<School> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回School集合</returns>
        public List<School> GetSchools(School obj, string where)
        {
            obj.IsDeleted = false;

            List<School> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回School集合</returns>
        public List<School> GetSchools(School obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<School> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回School集合</returns>
        public List<School> GetSchools(School obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<School> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回School集合</returns>
        public PagedList<School> GetSchools(int pageIndex, int pageCount)
        {
            PagedList<School> objs = os.GetObjects(new School() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回School集合</returns>
        public PagedList<School> GetSchools(School obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<School> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回School集合</returns>
        public PagedList<School> GetSchools(string sql, int pageIndex, int pageCount)
        {
            PagedList<School> objs = os.GetObjects<School>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回School集合</returns>
        public PagedList<School> GetSchools(School obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<School> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回School集合</returns>
        public PagedList<School> GetSchools(School obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<School> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取School集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回School集合</returns>
        public PagedList<School> GetSchools(School obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<School> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取School
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回School</returns>
        public School GetSchool(School obj)
        {
			obj.IsDeleted = false;
			
            School entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取School
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回School</returns>
        public School GetSchool(int id)
        {
            School entity = os.GetObject(new School { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class SchoolService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public SchoolService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public SchoolService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}