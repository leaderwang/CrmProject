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
    public partial class View_Student:INotifyPropertyChanged
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
        [ColumnAttribute("ID", false, false, false)]
        public Int32 ID { get { return _ID;} set{_ID = value;OnPropertyChanged("ID");} } 


        /// <summary>
        ///StudentNo
        /// </summary>
        private String _StudentNo;
        /// <summary>
        ///StudentNo
        /// </summary>
        [ColumnAttribute("StudentNo", false, false, false)]
        public String StudentNo { get { return _StudentNo;} set{_StudentNo = value;OnPropertyChanged("StudentNo");} } 


        /// <summary>
        ///UserName
        /// </summary>
        private String _UserName;
        /// <summary>
        ///UserName
        /// </summary>
        [ColumnAttribute("UserName", false, false, false)]
        public String UserName { get { return _UserName;} set{_UserName = value;OnPropertyChanged("UserName");} } 


        /// <summary>
        ///EnglishName
        /// </summary>
        private String _EnglishName;
        /// <summary>
        ///EnglishName
        /// </summary>
        [ColumnAttribute("EnglishName", false, false, true)]
        public String EnglishName { get { return _EnglishName;} set{_EnglishName = value;OnPropertyChanged("EnglishName");} } 


        /// <summary>
        ///Type
        /// </summary>
        private Int32 _Type;
        /// <summary>
        ///Type
        /// </summary>
        [ColumnAttribute("Type", false, false, false)]
        public Int32 Type { get { return _Type;} set{_Type = value;OnPropertyChanged("Type");} } 


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
        ///IDcard
        /// </summary>
        private String _IDcard;
        /// <summary>
        ///IDcard
        /// </summary>
        [ColumnAttribute("IDcard", false, false, true)]
        public String IDcard { get { return _IDcard;} set{_IDcard = value;OnPropertyChanged("IDcard");} } 


        /// <summary>
        ///BirthDate
        /// </summary>
        private String _BirthDate;
        /// <summary>
        ///BirthDate
        /// </summary>
        [ColumnAttribute("BirthDate", false, false, true)]
        public String BirthDate { get { return _BirthDate;} set{_BirthDate = value;OnPropertyChanged("BirthDate");} } 


        /// <summary>
        ///Mobile
        /// </summary>
        private String _Mobile;
        /// <summary>
        ///Mobile
        /// </summary>
        [ColumnAttribute("Mobile", false, false, true)]
        public String Mobile { get { return _Mobile;} set{_Mobile = value;OnPropertyChanged("Mobile");} } 


        /// <summary>
        ///TelePhone
        /// </summary>
        private String _TelePhone;
        /// <summary>
        ///TelePhone
        /// </summary>
        [ColumnAttribute("TelePhone", false, false, true)]
        public String TelePhone { get { return _TelePhone;} set{_TelePhone = value;OnPropertyChanged("TelePhone");} } 


        /// <summary>
        ///AttendSchoolID
        /// </summary>
        private Int32? _AttendSchoolID;
        /// <summary>
        ///AttendSchoolID
        /// </summary>
        [ColumnAttribute("AttendSchoolID", false, false, true)]
        public Int32? AttendSchoolID { get { return _AttendSchoolID;} set{_AttendSchoolID = value;OnPropertyChanged("AttendSchoolID");} } 


        /// <summary>
        ///SchoolName
        /// </summary>
        private String _SchoolName;
        /// <summary>
        ///SchoolName
        /// </summary>
        [ColumnAttribute("SchoolName", false, false, true)]
        public String SchoolName { get { return _SchoolName;} set{_SchoolName = value;OnPropertyChanged("SchoolName");} } 


        /// <summary>
        ///Avatar
        /// </summary>
        private String _Avatar;
        /// <summary>
        ///Avatar
        /// </summary>
        [ColumnAttribute("Avatar", false, false, true)]
        public String Avatar { get { return _Avatar;} set{_Avatar = value;OnPropertyChanged("Avatar");} } 


        /// <summary>
        ///Address
        /// </summary>
        private String _Address;
        /// <summary>
        ///Address
        /// </summary>
        [ColumnAttribute("Address", false, false, true)]
        public String Address { get { return _Address;} set{_Address = value;OnPropertyChanged("Address");} } 


        /// <summary>
        ///TelOfficerID
        /// </summary>
        private Int32? _TelOfficerID;
        /// <summary>
        ///TelOfficerID
        /// </summary>
        [ColumnAttribute("TelOfficerID", false, false, true)]
        public Int32? TelOfficerID { get { return _TelOfficerID;} set{_TelOfficerID = value;OnPropertyChanged("TelOfficerID");} } 


        /// <summary>
        ///TelOfficerName
        /// </summary>
        private String _TelOfficerName;
        /// <summary>
        ///TelOfficerName
        /// </summary>
        [ColumnAttribute("TelOfficerName", false, false, true)]
        public String TelOfficerName { get { return _TelOfficerName;} set{_TelOfficerName = value;OnPropertyChanged("TelOfficerName");} } 


        /// <summary>
        ///MarOfficerID
        /// </summary>
        private Int32? _MarOfficerID;
        /// <summary>
        ///MarOfficerID
        /// </summary>
        [ColumnAttribute("MarOfficerID", false, false, true)]
        public Int32? MarOfficerID { get { return _MarOfficerID;} set{_MarOfficerID = value;OnPropertyChanged("MarOfficerID");} } 


        /// <summary>
        ///MarOfficerName
        /// </summary>
        private String _MarOfficerName;
        /// <summary>
        ///MarOfficerName
        /// </summary>
        [ColumnAttribute("MarOfficerName", false, false, true)]
        public String MarOfficerName { get { return _MarOfficerName;} set{_MarOfficerName = value;OnPropertyChanged("MarOfficerName");} } 


        /// <summary>
        ///Email
        /// </summary>
        private String _Email;
        /// <summary>
        ///Email
        /// </summary>
        [ColumnAttribute("Email", false, false, true)]
        public String Email { get { return _Email;} set{_Email = value;OnPropertyChanged("Email");} } 


        /// <summary>
        ///QQ
        /// </summary>
        private String _QQ;
        /// <summary>
        ///QQ
        /// </summary>
        [ColumnAttribute("QQ", false, false, true)]
        public String QQ { get { return _QQ;} set{_QQ = value;OnPropertyChanged("QQ");} } 


        /// <summary>
        ///WeiXin
        /// </summary>
        private String _WeiXin;
        /// <summary>
        ///WeiXin
        /// </summary>
        [ColumnAttribute("WeiXin", false, false, true)]
        public String WeiXin { get { return _WeiXin;} set{_WeiXin = value;OnPropertyChanged("WeiXin");} } 


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
        private DateTime _CreateDate;
        /// <summary>
        ///CreateDate
        /// </summary>
        [ColumnAttribute("CreateDate", false, false, false)]
        public DateTime CreateDate { get { return _CreateDate;} set{_CreateDate = value;OnPropertyChanged("CreateDate");} } 


        /// <summary>
        ///CreateUserID
        /// </summary>
        private Int32 _CreateUserID;
        /// <summary>
        ///CreateUserID
        /// </summary>
        [ColumnAttribute("CreateUserID", false, false, false)]
        public Int32 CreateUserID { get { return _CreateUserID;} set{_CreateUserID = value;OnPropertyChanged("CreateUserID");} } 


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
    public partial class View_StudentLogic
    {
        /// <summary>
        /// View_Student数据操作对象
        /// </summary>
        private View_StudentService os = new View_StudentService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public View_StudentLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public View_StudentLogic(DBContext obj)
        {
            os = new View_StudentService(obj);
        }
        /// <summary>
        /// 添加View_Student
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(View_Student obj)
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
        /// 添加View_Student
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(View_Student obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [View_Student]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<View_Student> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (View_Student item in obj)
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
        /// 修改View_Student
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(View_Student obj)
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
        public bool Update(List<View_Student> olts)
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
        /// 根据编号删除View_Student，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new View_Student { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除View_Student，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(View_Student obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<View_Student>(obj);
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
        /// 删除View_Student集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<View_Student> objs)
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
        /// 根据编号删除View_Student，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new View_Student { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除View_Student，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(View_Student obj)
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
        /// 根据编号删除View_Student，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<View_Student> objs)
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
        /// 获取View_Student集合
        /// </summary>
        /// <returns>返回View_Student集合</returns>
        public List<View_Student> GetView_Students()
        {
            List<View_Student> objs = os.GetObjects<View_Student>(new View_Student() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Student集合</returns>
        public List<View_Student> GetView_Students(View_Student obj)
        {
            obj.IsDeleted = false;

            List<View_Student> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回View_Student集合</returns>
        public List<View_Student> GetView_Students(View_Student obj, string where)
        {
            obj.IsDeleted = false;

            List<View_Student> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回View_Student集合</returns>
        public List<View_Student> GetView_Students(View_Student obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<View_Student> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回View_Student集合</returns>
        public List<View_Student> GetView_Students(View_Student obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<View_Student> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回View_Student集合</returns>
        public PagedList<View_Student> GetView_Students(int pageIndex, int pageCount)
        {
            PagedList<View_Student> objs = os.GetObjects(new View_Student() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Student集合</returns>
        public PagedList<View_Student> GetView_Students(View_Student obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<View_Student> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Student集合</returns>
        public PagedList<View_Student> GetView_Students(string sql, int pageIndex, int pageCount)
        {
            PagedList<View_Student> objs = os.GetObjects<View_Student>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回View_Student集合</returns>
        public PagedList<View_Student> GetView_Students(View_Student obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<View_Student> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回View_Student集合</returns>
        public PagedList<View_Student> GetView_Students(View_Student obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<View_Student> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取View_Student集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回View_Student集合</returns>
        public PagedList<View_Student> GetView_Students(View_Student obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<View_Student> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取View_Student
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Student</returns>
        public View_Student GetView_Student(View_Student obj)
        {
			obj.IsDeleted = false;
			
            View_Student entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取View_Student
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回View_Student</returns>
        public View_Student GetView_Student(int id)
        {
            View_Student entity = os.GetObject(new View_Student { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class View_StudentService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public View_StudentService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public View_StudentService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}