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
    public partial class Customer:INotifyPropertyChanged
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
        ///OpenID
        /// </summary>
        private String _OpenID;
        /// <summary>
        ///OpenID
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
        ///RealName
        /// </summary>
        private String _RealName;
        /// <summary>
        ///RealName
        /// </summary>
        [ColumnAttribute("RealName", false, false, true)]
        public String RealName { get { return _RealName;} set{_RealName = value;OnPropertyChanged("RealName");} } 


        /// <summary>
        ///手机号
        /// </summary>
        private String _Mobile;
        /// <summary>
        ///手机号
        /// </summary>
        [ColumnAttribute("Mobile", false, false, false)]
        public String Mobile { get { return _Mobile;} set{_Mobile = value;OnPropertyChanged("Mobile");} } 


        /// <summary>
        ///宣言
        /// </summary>
        private String _Province;
        /// <summary>
        ///宣言
        /// </summary>
        [ColumnAttribute("Province", false, false, true)]
        public String Province { get { return _Province;} set{_Province = value;OnPropertyChanged("Province");} } 


        /// <summary>
        ///City
        /// </summary>
        private String _City;
        /// <summary>
        ///City
        /// </summary>
        [ColumnAttribute("City", false, false, true)]
        public String City { get { return _City;} set{_City = value;OnPropertyChanged("City");} } 


        /// <summary>
        ///身份证号
        /// </summary>
        private String _Region;
        /// <summary>
        ///身份证号
        /// </summary>
        [ColumnAttribute("Region", false, false, true)]
        public String Region { get { return _Region;} set{_Region = value;OnPropertyChanged("Region");} } 


        /// <summary>
        ///地址
        /// </summary>
        private String _Address;
        /// <summary>
        ///地址
        /// </summary>
        [ColumnAttribute("Address", false, false, true)]
        public String Address { get { return _Address;} set{_Address = value;OnPropertyChanged("Address");} } 


        /// <summary>
        ///邮件地址
        /// </summary>
        private String _Email;
        /// <summary>
        ///邮件地址
        /// </summary>
        [ColumnAttribute("Email", false, false, true)]
        public String Email { get { return _Email;} set{_Email = value;OnPropertyChanged("Email");} } 


        /// <summary>
        ///头像
        /// </summary>
        private String _Avatar;
        /// <summary>
        ///头像
        /// </summary>
        [ColumnAttribute("Avatar", false, false, true)]
        public String Avatar { get { return _Avatar;} set{_Avatar = value;OnPropertyChanged("Avatar");} } 


        /// <summary>
        ///总积分
        /// </summary>
        private Int32 _TotalScore;
        /// <summary>
        ///总积分
        /// </summary>
        [ColumnAttribute("TotalScore", false, false, false)]
        public Int32 TotalScore { get { return _TotalScore;} set{_TotalScore = value;OnPropertyChanged("TotalScore");} } 


        /// <summary>
        ///当前积分
        /// </summary>
        private Int32 _CurrentScore;
        /// <summary>
        ///当前积分
        /// </summary>
        [ColumnAttribute("CurrentScore", false, false, false)]
        public Int32 CurrentScore { get { return _CurrentScore;} set{_CurrentScore = value;OnPropertyChanged("CurrentScore");} } 


        /// <summary>
        ///用户状态
        /// </summary>
        private Int32 _Status;
        /// <summary>
        ///用户状态
        /// </summary>
        [ColumnAttribute("Status", false, false, false)]
        public Int32 Status { get { return _Status;} set{_Status = value;OnPropertyChanged("Status");} } 


        /// <summary>
        ///Tab
        /// </summary>
        private String _Tab;
        /// <summary>
        ///Tab
        /// </summary>
        [ColumnAttribute("Tab", false, false, true)]
        public String Tab { get { return _Tab;} set{_Tab = value;OnPropertyChanged("Tab");} } 


        /// <summary>
        ///创建时间
        /// </summary>
        private DateTime _CreateDate;
        /// <summary>
        ///创建时间
        /// </summary>
        [ColumnAttribute("CreateDate", false, false, false)]
        public DateTime CreateDate { get { return _CreateDate;} set{_CreateDate = value;OnPropertyChanged("CreateDate");} } 


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
        private Boolean _IsDeleted;
        /// <summary>
        ///IsDeleted
        /// </summary>
        [ColumnAttribute("IsDeleted", false, false, false)]
        public Boolean IsDeleted { get { return _IsDeleted;} set{_IsDeleted = value;OnPropertyChanged("IsDeleted");} } 




    }
	#endregion
	#region 基本业务
    public partial class CustomerLogic
    {
        /// <summary>
        /// Customer数据操作对象
        /// </summary>
        private CustomerService os = new CustomerService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public CustomerLogic(DBContext obj)
        {
            os = new CustomerService(obj);
        }
        /// <summary>
        /// 添加Customer
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(Customer obj)
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
        /// 添加Customer
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(Customer obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [Customer]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<Customer> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (Customer item in obj)
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
        /// 修改Customer
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(Customer obj)
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
        public bool Update(List<Customer> olts)
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
        /// 根据编号删除Customer，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new Customer { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除Customer，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(Customer obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<Customer>(obj);
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
        /// 删除Customer集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<Customer> objs)
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
        /// 根据编号删除Customer，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new Customer { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除Customer，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(Customer obj)
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
        /// 根据编号删除Customer，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<Customer> objs)
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
        /// 获取Customer集合
        /// </summary>
        /// <returns>返回Customer集合</returns>
        public List<Customer> GetCustomers()
        {
            List<Customer> objs = os.GetObjects<Customer>(new Customer() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Customer集合</returns>
        public List<Customer> GetCustomers(Customer obj)
        {
            obj.IsDeleted = false;

            List<Customer> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回Customer集合</returns>
        public List<Customer> GetCustomers(Customer obj, string where)
        {
            obj.IsDeleted = false;

            List<Customer> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Customer集合</returns>
        public List<Customer> GetCustomers(Customer obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<Customer> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回Customer集合</returns>
        public List<Customer> GetCustomers(Customer obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<Customer> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回Customer集合</returns>
        public PagedList<Customer> GetCustomers(int pageIndex, int pageCount)
        {
            PagedList<Customer> objs = os.GetObjects(new Customer() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Customer集合</returns>
        public PagedList<Customer> GetCustomers(Customer obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<Customer> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Customer集合</returns>
        public PagedList<Customer> GetCustomers(string sql, int pageIndex, int pageCount)
        {
            PagedList<Customer> objs = os.GetObjects<Customer>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回Customer集合</returns>
        public PagedList<Customer> GetCustomers(Customer obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<Customer> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Customer集合</returns>
        public PagedList<Customer> GetCustomers(Customer obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Customer> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取Customer集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Customer集合</returns>
        public PagedList<Customer> GetCustomers(Customer obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Customer> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取Customer
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Customer</returns>
        public Customer GetCustomer(Customer obj)
        {
			obj.IsDeleted = false;
			
            Customer entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取Customer
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回Customer</returns>
        public Customer GetCustomer(int id)
        {
            Customer entity = os.GetObject(new Customer { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class CustomerService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public CustomerService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}