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
    public partial class View_Member:INotifyPropertyChanged
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
        ///CompanyID
        /// </summary>
        private Int32 _CompanyID;
        /// <summary>
        ///CompanyID
        /// </summary>
        [ColumnAttribute("CompanyID", false, false, false)]
        public Int32 CompanyID { get { return _CompanyID;} set{_CompanyID = value;OnPropertyChanged("CompanyID");} } 


        /// <summary>
        ///CompanyName
        /// </summary>
        private String _CompanyName;
        /// <summary>
        ///CompanyName
        /// </summary>
        [ColumnAttribute("CompanyName", false, false, true)]
        public String CompanyName { get { return _CompanyName;} set{_CompanyName = value;OnPropertyChanged("CompanyName");} } 


        /// <summary>
        ///RoleID
        /// </summary>
        private Int32 _RoleID;
        /// <summary>
        ///RoleID
        /// </summary>
        [ColumnAttribute("RoleID", false, false, false)]
        public Int32 RoleID { get { return _RoleID;} set{_RoleID = value;OnPropertyChanged("RoleID");} } 


        /// <summary>
        ///RoleName
        /// </summary>
        private String _RoleName;
        /// <summary>
        ///RoleName
        /// </summary>
        [ColumnAttribute("RoleName", false, false, true)]
        public String RoleName { get { return _RoleName;} set{_RoleName = value;OnPropertyChanged("RoleName");} } 


        /// <summary>
        ///UserNo
        /// </summary>
        private String _UserNo;
        /// <summary>
        ///UserNo
        /// </summary>
        [ColumnAttribute("UserNo", false, false, false)]
        public String UserNo { get { return _UserNo;} set{_UserNo = value;OnPropertyChanged("UserNo");} } 


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
        ///Password
        /// </summary>
        private String _Password;
        /// <summary>
        ///Password
        /// </summary>
        [ColumnAttribute("Password", false, false, true)]
        public String Password { get { return _Password;} set{_Password = value;OnPropertyChanged("Password");} } 


        /// <summary>
        ///PwdNotMD5
        /// </summary>
        private String _PwdNotMD5;
        /// <summary>
        ///PwdNotMD5
        /// </summary>
        [ColumnAttribute("PwdNotMD5", false, false, true)]
        public String PwdNotMD5 { get { return _PwdNotMD5;} set{_PwdNotMD5 = value;OnPropertyChanged("PwdNotMD5");} } 


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
        ///RealName
        /// </summary>
        private String _RealName;
        /// <summary>
        ///RealName
        /// </summary>
        [ColumnAttribute("RealName", false, false, false)]
        public String RealName { get { return _RealName;} set{_RealName = value;OnPropertyChanged("RealName");} } 


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
        ///Status
        /// </summary>
        private Int32? _Status;
        /// <summary>
        ///Status
        /// </summary>
        [ColumnAttribute("Status", false, false, true)]
        public Int32? Status { get { return _Status;} set{_Status = value;OnPropertyChanged("Status");} } 


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
        ///Email
        /// </summary>
        private String _Email;
        /// <summary>
        ///Email
        /// </summary>
        [ColumnAttribute("Email", false, false, true)]
        public String Email { get { return _Email;} set{_Email = value;OnPropertyChanged("Email");} } 


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
    public partial class View_MemberLogic
    {
        /// <summary>
        /// View_Member数据操作对象
        /// </summary>
        private View_MemberService os = new View_MemberService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public View_MemberLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public View_MemberLogic(DBContext obj)
        {
            os = new View_MemberService(obj);
        }
        /// <summary>
        /// 添加View_Member
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(View_Member obj)
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
        /// 添加View_Member
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(View_Member obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [View_Member]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<View_Member> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (View_Member item in obj)
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
        /// 修改View_Member
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(View_Member obj)
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
        public bool Update(List<View_Member> olts)
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
        /// 根据编号删除View_Member，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new View_Member { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除View_Member，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(View_Member obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<View_Member>(obj);
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
        /// 删除View_Member集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<View_Member> objs)
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
        /// 根据编号删除View_Member，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new View_Member { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除View_Member，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(View_Member obj)
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
        /// 根据编号删除View_Member，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<View_Member> objs)
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
        /// 获取View_Member集合
        /// </summary>
        /// <returns>返回View_Member集合</returns>
        public List<View_Member> GetView_Members()
        {
            List<View_Member> objs = os.GetObjects<View_Member>(new View_Member() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Member集合</returns>
        public List<View_Member> GetView_Members(View_Member obj)
        {
            obj.IsDeleted = false;

            List<View_Member> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回View_Member集合</returns>
        public List<View_Member> GetView_Members(View_Member obj, string where)
        {
            obj.IsDeleted = false;

            List<View_Member> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回View_Member集合</returns>
        public List<View_Member> GetView_Members(View_Member obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<View_Member> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回View_Member集合</returns>
        public List<View_Member> GetView_Members(View_Member obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<View_Member> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回View_Member集合</returns>
        public PagedList<View_Member> GetView_Members(int pageIndex, int pageCount)
        {
            PagedList<View_Member> objs = os.GetObjects(new View_Member() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Member集合</returns>
        public PagedList<View_Member> GetView_Members(View_Member obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<View_Member> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Member集合</returns>
        public PagedList<View_Member> GetView_Members(string sql, int pageIndex, int pageCount)
        {
            PagedList<View_Member> objs = os.GetObjects<View_Member>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回View_Member集合</returns>
        public PagedList<View_Member> GetView_Members(View_Member obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<View_Member> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回View_Member集合</returns>
        public PagedList<View_Member> GetView_Members(View_Member obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<View_Member> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取View_Member集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回View_Member集合</returns>
        public PagedList<View_Member> GetView_Members(View_Member obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<View_Member> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取View_Member
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回View_Member</returns>
        public View_Member GetView_Member(View_Member obj)
        {
			obj.IsDeleted = false;
			
            View_Member entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取View_Member
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回View_Member</returns>
        public View_Member GetView_Member(int id)
        {
            View_Member entity = os.GetObject(new View_Member { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class View_MemberService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public View_MemberService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public View_MemberService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}