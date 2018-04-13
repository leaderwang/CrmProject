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
    public partial class MaterielRecord:INotifyPropertyChanged
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
        ///MaterielID
        /// </summary>
        private Int32 _MaterielID;
        /// <summary>
        ///MaterielID
        /// </summary>
        [ColumnAttribute("MaterielID", false, false, false)]
        public Int32 MaterielID { get { return _MaterielID;} set{_MaterielID = value;OnPropertyChanged("MaterielID");} } 


        /// <summary>
        ///出入库数量
        /// </summary>
        private Int32 _Count;
        /// <summary>
        ///出入库数量
        /// </summary>
        [ColumnAttribute("Count", false, false, false)]
        public Int32 Count { get { return _Count;} set{_Count = value;OnPropertyChanged("Count");} } 


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
        ///申请编号
        /// </summary>
        private String _RequestNo;
        /// <summary>
        ///申请编号
        /// </summary>
        [ColumnAttribute("RequestNo", false, false, true)]
        public String RequestNo { get { return _RequestNo;} set{_RequestNo = value;OnPropertyChanged("RequestNo");} } 


        /// <summary>
        ///简述
        /// </summary>
        private String _Summary;
        /// <summary>
        ///简述
        /// </summary>
        [ColumnAttribute("Summary", false, false, true)]
        public String Summary { get { return _Summary;} set{_Summary = value;OnPropertyChanged("Summary");} } 


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
    public partial class MaterielRecordLogic
    {
        /// <summary>
        /// MaterielRecord数据操作对象
        /// </summary>
        private MaterielRecordService os = new MaterielRecordService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterielRecordLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public MaterielRecordLogic(DBContext obj)
        {
            os = new MaterielRecordService(obj);
        }
        /// <summary>
        /// 添加MaterielRecord
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(MaterielRecord obj)
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
        /// 添加MaterielRecord
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(MaterielRecord obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [MaterielRecord]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<MaterielRecord> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (MaterielRecord item in obj)
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
        /// 修改MaterielRecord
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(MaterielRecord obj)
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
        public bool Update(List<MaterielRecord> olts)
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
        /// 根据编号删除MaterielRecord，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new MaterielRecord { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除MaterielRecord，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(MaterielRecord obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<MaterielRecord>(obj);
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
        /// 删除MaterielRecord集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<MaterielRecord> objs)
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
        /// 根据编号删除MaterielRecord，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new MaterielRecord { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除MaterielRecord，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(MaterielRecord obj)
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
        /// 根据编号删除MaterielRecord，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<MaterielRecord> objs)
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
        /// 获取MaterielRecord集合
        /// </summary>
        /// <returns>返回MaterielRecord集合</returns>
        public List<MaterielRecord> GetMaterielRecords()
        {
            List<MaterielRecord> objs = os.GetObjects<MaterielRecord>(new MaterielRecord() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回MaterielRecord集合</returns>
        public List<MaterielRecord> GetMaterielRecords(MaterielRecord obj)
        {
            obj.IsDeleted = false;

            List<MaterielRecord> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回MaterielRecord集合</returns>
        public List<MaterielRecord> GetMaterielRecords(MaterielRecord obj, string where)
        {
            obj.IsDeleted = false;

            List<MaterielRecord> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回MaterielRecord集合</returns>
        public List<MaterielRecord> GetMaterielRecords(MaterielRecord obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<MaterielRecord> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回MaterielRecord集合</returns>
        public List<MaterielRecord> GetMaterielRecords(MaterielRecord obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<MaterielRecord> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回MaterielRecord集合</returns>
        public PagedList<MaterielRecord> GetMaterielRecords(int pageIndex, int pageCount)
        {
            PagedList<MaterielRecord> objs = os.GetObjects(new MaterielRecord() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回MaterielRecord集合</returns>
        public PagedList<MaterielRecord> GetMaterielRecords(MaterielRecord obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<MaterielRecord> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回MaterielRecord集合</returns>
        public PagedList<MaterielRecord> GetMaterielRecords(string sql, int pageIndex, int pageCount)
        {
            PagedList<MaterielRecord> objs = os.GetObjects<MaterielRecord>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回MaterielRecord集合</returns>
        public PagedList<MaterielRecord> GetMaterielRecords(MaterielRecord obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<MaterielRecord> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回MaterielRecord集合</returns>
        public PagedList<MaterielRecord> GetMaterielRecords(MaterielRecord obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<MaterielRecord> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取MaterielRecord集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回MaterielRecord集合</returns>
        public PagedList<MaterielRecord> GetMaterielRecords(MaterielRecord obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<MaterielRecord> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取MaterielRecord
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回MaterielRecord</returns>
        public MaterielRecord GetMaterielRecord(MaterielRecord obj)
        {
			obj.IsDeleted = false;
			
            MaterielRecord entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取MaterielRecord
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回MaterielRecord</returns>
        public MaterielRecord GetMaterielRecord(int id)
        {
            MaterielRecord entity = os.GetObject(new MaterielRecord { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class MaterielRecordService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public MaterielRecordService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public MaterielRecordService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}