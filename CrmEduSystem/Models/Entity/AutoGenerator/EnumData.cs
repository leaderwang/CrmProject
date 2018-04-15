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
    public partial class EnumData:INotifyPropertyChanged
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
        ///编号
        /// </summary>
        private Int32 _ID;
        /// <summary>
        ///编号
        /// </summary>
        [ColumnAttribute("ID", false, true, false)]
        public Int32 ID { get { return _ID;} set{_ID = value;OnPropertyChanged("ID");} } 


        /// <summary>
        ///父级ID
        /// </summary>
        private Int32 _ParentID;
        /// <summary>
        ///父级ID
        /// </summary>
        [ColumnAttribute("ParentID", false, false, false)]
        public Int32 ParentID { get { return _ParentID;} set{_ParentID = value;OnPropertyChanged("ParentID");} } 


        /// <summary>
        ///名称
        /// </summary>
        private String _EnumName;
        /// <summary>
        ///名称
        /// </summary>
        [ColumnAttribute("EnumName", false, false, false)]
        public String EnumName { get { return _EnumName;} set{_EnumName = value;OnPropertyChanged("EnumName");} } 


        /// <summary>
        ///数值
        /// </summary>
        private String _EnumValue;
        /// <summary>
        ///数值
        /// </summary>
        [ColumnAttribute("EnumValue", false, false, false)]
        public String EnumValue { get { return _EnumValue;} set{_EnumValue = value;OnPropertyChanged("EnumValue");} } 


        /// <summary>
        ///排序
        /// </summary>
        private Int32? _Sort;
        /// <summary>
        ///排序
        /// </summary>
        [ColumnAttribute("Sort", false, false, true)]
        public Int32? Sort { get { return _Sort;} set{_Sort = value;OnPropertyChanged("Sort");} } 


        /// <summary>
        ///Level
        /// </summary>
        private Int32 _Level;
        /// <summary>
        ///Level
        /// </summary>
        [ColumnAttribute("Level", false, false, false)]
        public Int32 Level { get { return _Level;} set{_Level = value;OnPropertyChanged("Level");} } 


        /// <summary>
        ///是否删除
        /// </summary>
        private Boolean _IsDeleted;
        /// <summary>
        ///是否删除
        /// </summary>
        [ColumnAttribute("IsDeleted", false, false, false)]
        public Boolean IsDeleted { get { return _IsDeleted;} set{_IsDeleted = value;OnPropertyChanged("IsDeleted");} } 


        /// <summary>
        ///TypeID
        /// </summary>
        private Int32? _TypeID;
        /// <summary>
        ///TypeID
        /// </summary>
        [ColumnAttribute("TypeID", false, false, true)]
        public Int32? TypeID { get { return _TypeID;} set{_TypeID = value;OnPropertyChanged("TypeID");} } 


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




    }
	#endregion
	#region 基本业务
    public partial class EnumDataLogic
    {
        /// <summary>
        /// EnumData数据操作对象
        /// </summary>
        private EnumDataService os = new EnumDataService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public EnumDataLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public EnumDataLogic(DBContext obj)
        {
            os = new EnumDataService(obj);
        }
        /// <summary>
        /// 添加EnumData
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(EnumData obj)
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
        /// 添加EnumData
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(EnumData obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [EnumData]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<EnumData> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (EnumData item in obj)
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
        /// 修改EnumData
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(EnumData obj)
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
        public bool Update(List<EnumData> olts)
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
        /// 根据编号删除EnumData，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new EnumData { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除EnumData，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(EnumData obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<EnumData>(obj);
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
        /// 删除EnumData集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<EnumData> objs)
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
        /// 根据编号删除EnumData，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new EnumData { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除EnumData，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(EnumData obj)
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
        /// 根据编号删除EnumData，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<EnumData> objs)
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
        /// 获取EnumData集合
        /// </summary>
        /// <returns>返回EnumData集合</returns>
        public List<EnumData> GetEnumDatas()
        {
            List<EnumData> objs = os.GetObjects<EnumData>(new EnumData() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回EnumData集合</returns>
        public List<EnumData> GetEnumDatas(EnumData obj)
        {
            obj.IsDeleted = false;

            List<EnumData> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回EnumData集合</returns>
        public List<EnumData> GetEnumDatas(EnumData obj, string where)
        {
            obj.IsDeleted = false;

            List<EnumData> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回EnumData集合</returns>
        public List<EnumData> GetEnumDatas(EnumData obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<EnumData> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回EnumData集合</returns>
        public List<EnumData> GetEnumDatas(EnumData obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<EnumData> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回EnumData集合</returns>
        public PagedList<EnumData> GetEnumDatas(int pageIndex, int pageCount)
        {
            PagedList<EnumData> objs = os.GetObjects(new EnumData() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回EnumData集合</returns>
        public PagedList<EnumData> GetEnumDatas(EnumData obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<EnumData> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回EnumData集合</returns>
        public PagedList<EnumData> GetEnumDatas(string sql, int pageIndex, int pageCount)
        {
            PagedList<EnumData> objs = os.GetObjects<EnumData>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回EnumData集合</returns>
        public PagedList<EnumData> GetEnumDatas(EnumData obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<EnumData> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回EnumData集合</returns>
        public PagedList<EnumData> GetEnumDatas(EnumData obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<EnumData> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取EnumData集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回EnumData集合</returns>
        public PagedList<EnumData> GetEnumDatas(EnumData obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<EnumData> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取EnumData
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回EnumData</returns>
        public EnumData GetEnumData(EnumData obj)
        {
			obj.IsDeleted = false;
			
            EnumData entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取EnumData
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回EnumData</returns>
        public EnumData GetEnumData(int id)
        {
            EnumData entity = os.GetObject(new EnumData { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class EnumDataService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public EnumDataService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public EnumDataService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}