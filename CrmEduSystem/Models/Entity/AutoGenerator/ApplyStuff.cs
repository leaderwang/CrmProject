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
    public partial class ApplyStuff:INotifyPropertyChanged
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
        ///Sort
        /// </summary>
        private Int32? _Sort;
        /// <summary>
        ///Sort
        /// </summary>
        [ColumnAttribute("Sort", false, false, true)]
        public Int32? Sort { get { return _Sort;} set{_Sort = value;OnPropertyChanged("Sort");} } 


        /// <summary>
        ///MeetingID
        /// </summary>
        private Int32? _MeetingID;
        /// <summary>
        ///MeetingID
        /// </summary>
        [ColumnAttribute("MeetingID", false, false, true)]
        public Int32? MeetingID { get { return _MeetingID;} set{_MeetingID = value;OnPropertyChanged("MeetingID");} } 


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
        ///ApplyDate
        /// </summary>
        private DateTime? _ApplyDate;
        /// <summary>
        ///ApplyDate
        /// </summary>
        [ColumnAttribute("ApplyDate", false, false, true)]
        public DateTime? ApplyDate { get { return _ApplyDate;} set{_ApplyDate = value;OnPropertyChanged("ApplyDate");} } 


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
        ///Hospital
        /// </summary>
        private String _Hospital;
        /// <summary>
        ///Hospital
        /// </summary>
        [ColumnAttribute("Hospital", false, false, true)]
        public String Hospital { get { return _Hospital;} set{_Hospital = value;OnPropertyChanged("Hospital");} } 


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
        ///Address
        /// </summary>
        private String _Address;
        /// <summary>
        ///Address
        /// </summary>
        [ColumnAttribute("Address", false, false, true)]
        public String Address { get { return _Address;} set{_Address = value;OnPropertyChanged("Address");} } 


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
        ///VerifyStatus
        /// </summary>
        private Int32? _VerifyStatus;
        /// <summary>
        ///VerifyStatus
        /// </summary>
        [ColumnAttribute("VerifyStatus", false, false, true)]
        public Int32? VerifyStatus { get { return _VerifyStatus;} set{_VerifyStatus = value;OnPropertyChanged("VerifyStatus");} } 


        /// <summary>
        ///VerifyMemberID
        /// </summary>
        private Int32? _VerifyMemberID;
        /// <summary>
        ///VerifyMemberID
        /// </summary>
        [ColumnAttribute("VerifyMemberID", false, false, true)]
        public Int32? VerifyMemberID { get { return _VerifyMemberID;} set{_VerifyMemberID = value;OnPropertyChanged("VerifyMemberID");} } 


        /// <summary>
        ///VerifyRemark
        /// </summary>
        private String _VerifyRemark;
        /// <summary>
        ///VerifyRemark
        /// </summary>
        [ColumnAttribute("VerifyRemark", false, false, true)]
        public String VerifyRemark { get { return _VerifyRemark;} set{_VerifyRemark = value;OnPropertyChanged("VerifyRemark");} } 


        /// <summary>
        ///VerifyDate
        /// </summary>
        private DateTime? _VerifyDate;
        /// <summary>
        ///VerifyDate
        /// </summary>
        [ColumnAttribute("VerifyDate", false, false, true)]
        public DateTime? VerifyDate { get { return _VerifyDate;} set{_VerifyDate = value;OnPropertyChanged("VerifyDate");} } 


        /// <summary>
        ///ApplyRemark
        /// </summary>
        private String _ApplyRemark;
        /// <summary>
        ///ApplyRemark
        /// </summary>
        [ColumnAttribute("ApplyRemark", false, false, true)]
        public String ApplyRemark { get { return _ApplyRemark;} set{_ApplyRemark = value;OnPropertyChanged("ApplyRemark");} } 




    }
	#endregion
	#region 基本业务
    public partial class ApplyStuffLogic
    {
        /// <summary>
        /// ApplyStuff数据操作对象
        /// </summary>
        private ApplyStuffService os = new ApplyStuffService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApplyStuffLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public ApplyStuffLogic(DBContext obj)
        {
            os = new ApplyStuffService(obj);
        }
        /// <summary>
        /// 添加ApplyStuff
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(ApplyStuff obj)
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
        /// 添加ApplyStuff
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(ApplyStuff obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [ApplyStuff]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<ApplyStuff> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (ApplyStuff item in obj)
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
        /// 修改ApplyStuff
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(ApplyStuff obj)
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
        public bool Update(List<ApplyStuff> olts)
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
        /// 根据编号删除ApplyStuff，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new ApplyStuff { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除ApplyStuff，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(ApplyStuff obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<ApplyStuff>(obj);
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
        /// 删除ApplyStuff集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<ApplyStuff> objs)
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
        /// 根据编号删除ApplyStuff，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new ApplyStuff { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除ApplyStuff，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(ApplyStuff obj)
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
        /// 根据编号删除ApplyStuff，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<ApplyStuff> objs)
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
        /// 获取ApplyStuff集合
        /// </summary>
        /// <returns>返回ApplyStuff集合</returns>
        public List<ApplyStuff> GetApplyStuffs()
        {
            List<ApplyStuff> objs = os.GetObjects<ApplyStuff>(new ApplyStuff() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回ApplyStuff集合</returns>
        public List<ApplyStuff> GetApplyStuffs(ApplyStuff obj)
        {
            obj.IsDeleted = false;

            List<ApplyStuff> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回ApplyStuff集合</returns>
        public List<ApplyStuff> GetApplyStuffs(ApplyStuff obj, string where)
        {
            obj.IsDeleted = false;

            List<ApplyStuff> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回ApplyStuff集合</returns>
        public List<ApplyStuff> GetApplyStuffs(ApplyStuff obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<ApplyStuff> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回ApplyStuff集合</returns>
        public List<ApplyStuff> GetApplyStuffs(ApplyStuff obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<ApplyStuff> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回ApplyStuff集合</returns>
        public PagedList<ApplyStuff> GetApplyStuffs(int pageIndex, int pageCount)
        {
            PagedList<ApplyStuff> objs = os.GetObjects(new ApplyStuff() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回ApplyStuff集合</returns>
        public PagedList<ApplyStuff> GetApplyStuffs(ApplyStuff obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<ApplyStuff> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回ApplyStuff集合</returns>
        public PagedList<ApplyStuff> GetApplyStuffs(string sql, int pageIndex, int pageCount)
        {
            PagedList<ApplyStuff> objs = os.GetObjects<ApplyStuff>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回ApplyStuff集合</returns>
        public PagedList<ApplyStuff> GetApplyStuffs(ApplyStuff obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<ApplyStuff> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回ApplyStuff集合</returns>
        public PagedList<ApplyStuff> GetApplyStuffs(ApplyStuff obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<ApplyStuff> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取ApplyStuff集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回ApplyStuff集合</returns>
        public PagedList<ApplyStuff> GetApplyStuffs(ApplyStuff obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<ApplyStuff> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取ApplyStuff
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回ApplyStuff</returns>
        public ApplyStuff GetApplyStuff(ApplyStuff obj)
        {
			obj.IsDeleted = false;
			
            ApplyStuff entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取ApplyStuff
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回ApplyStuff</returns>
        public ApplyStuff GetApplyStuff(int id)
        {
            ApplyStuff entity = os.GetObject(new ApplyStuff { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class ApplyStuffService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public ApplyStuffService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public ApplyStuffService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}