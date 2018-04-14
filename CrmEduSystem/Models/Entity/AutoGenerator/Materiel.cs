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
    public partial class Materiel:INotifyPropertyChanged
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
        ///物料名称
        /// </summary>
        private String _Title;
        /// <summary>
        ///物料名称
        /// </summary>
        [ColumnAttribute("Title", false, false, false)]
        public String Title { get { return _Title;} set{_Title = value;OnPropertyChanged("Title");} } 


        /// <summary>
        ///简介
        /// </summary>
        private String _Summary;
        /// <summary>
        ///简介
        /// </summary>
        [ColumnAttribute("Summary", false, false, true)]
        public String Summary { get { return _Summary;} set{_Summary = value;OnPropertyChanged("Summary");} } 


        /// <summary>
        ///当前库存
        /// </summary>
        private Int32 _Stock;
        /// <summary>
        ///当前库存
        /// </summary>
        [ColumnAttribute("Stock", false, false, false)]
        public Int32 Stock { get { return _Stock;} set{_Stock = value;OnPropertyChanged("Stock");} } 


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
        ///缩略图
        /// </summary>
        private String _Thumbs;
        /// <summary>
        ///缩略图
        /// </summary>
        [ColumnAttribute("Thumbs", false, false, true)]
        public String Thumbs { get { return _Thumbs;} set{_Thumbs = value;OnPropertyChanged("Thumbs");} } 


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
    public partial class MaterielLogic
    {
        /// <summary>
        /// Materiel数据操作对象
        /// </summary>
        private MaterielService os = new MaterielService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterielLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public MaterielLogic(DBContext obj)
        {
            os = new MaterielService(obj);
        }
        /// <summary>
        /// 添加Materiel
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(Materiel obj)
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
        /// 添加Materiel
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(Materiel obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [Materiel]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<Materiel> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (Materiel item in obj)
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
        /// 修改Materiel
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(Materiel obj)
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
        public bool Update(List<Materiel> olts)
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
        /// 根据编号删除Materiel，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new Materiel { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除Materiel，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(Materiel obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<Materiel>(obj);
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
        /// 删除Materiel集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<Materiel> objs)
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
        /// 根据编号删除Materiel，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new Materiel { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除Materiel，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(Materiel obj)
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
        /// 根据编号删除Materiel，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<Materiel> objs)
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
        /// 获取Materiel集合
        /// </summary>
        /// <returns>返回Materiel集合</returns>
        public List<Materiel> GetMateriels()
        {
            List<Materiel> objs = os.GetObjects<Materiel>(new Materiel() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Materiel集合</returns>
        public List<Materiel> GetMateriels(Materiel obj)
        {
            obj.IsDeleted = false;

            List<Materiel> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回Materiel集合</returns>
        public List<Materiel> GetMateriels(Materiel obj, string where)
        {
            obj.IsDeleted = false;

            List<Materiel> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Materiel集合</returns>
        public List<Materiel> GetMateriels(Materiel obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<Materiel> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回Materiel集合</returns>
        public List<Materiel> GetMateriels(Materiel obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<Materiel> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回Materiel集合</returns>
        public PagedList<Materiel> GetMateriels(int pageIndex, int pageCount)
        {
            PagedList<Materiel> objs = os.GetObjects(new Materiel() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Materiel集合</returns>
        public PagedList<Materiel> GetMateriels(Materiel obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<Materiel> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Materiel集合</returns>
        public PagedList<Materiel> GetMateriels(string sql, int pageIndex, int pageCount)
        {
            PagedList<Materiel> objs = os.GetObjects<Materiel>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回Materiel集合</returns>
        public PagedList<Materiel> GetMateriels(Materiel obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<Materiel> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Materiel集合</returns>
        public PagedList<Materiel> GetMateriels(Materiel obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Materiel> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取Materiel集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Materiel集合</returns>
        public PagedList<Materiel> GetMateriels(Materiel obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Materiel> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取Materiel
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Materiel</returns>
        public Materiel GetMateriel(Materiel obj)
        {
			obj.IsDeleted = false;
			
            Materiel entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取Materiel
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回Materiel</returns>
        public Materiel GetMateriel(int id)
        {
            Materiel entity = os.GetObject(new Materiel { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class MaterielService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public MaterielService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public MaterielService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}