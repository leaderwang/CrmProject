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
    public partial class Menu:INotifyPropertyChanged
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
        ///名称
        /// </summary>
        private String _Name;
        /// <summary>
        ///名称
        /// </summary>
        [ColumnAttribute("Name", false, false, true)]
        public String Name { get { return _Name;} set{_Name = value;OnPropertyChanged("Name");} } 


        /// <summary>
        ///父级ID
        /// </summary>
        private Int32? _ParentID;
        /// <summary>
        ///父级ID
        /// </summary>
        [ColumnAttribute("ParentID", false, false, true)]
        public Int32? ParentID { get { return _ParentID;} set{_ParentID = value;OnPropertyChanged("ParentID");} } 


        /// <summary>
        ///菜单图标
        /// </summary>
        private String _Icon;
        /// <summary>
        ///菜单图标
        /// </summary>
        [ColumnAttribute("Icon", false, false, true)]
        public String Icon { get { return _Icon;} set{_Icon = value;OnPropertyChanged("Icon");} } 


        /// <summary>
        ///链接地址
        /// </summary>
        private String _Url;
        /// <summary>
        ///链接地址
        /// </summary>
        [ColumnAttribute("Url", false, false, true)]
        public String Url { get { return _Url;} set{_Url = value;OnPropertyChanged("Url");} } 


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
        private Int32? _Level;
        /// <summary>
        ///Level
        /// </summary>
        [ColumnAttribute("Level", false, false, true)]
        public Int32? Level { get { return _Level;} set{_Level = value;OnPropertyChanged("Level");} } 


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
    public partial class MenuLogic
    {
        /// <summary>
        /// Menu数据操作对象
        /// </summary>
        private MenuService os = new MenuService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public MenuLogic(DBContext obj)
        {
            os = new MenuService(obj);
        }
        /// <summary>
        /// 添加Menu
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(Menu obj)
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
        /// 添加Menu
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(Menu obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [Menu]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<Menu> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (Menu item in obj)
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
        /// 修改Menu
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(Menu obj)
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
        public bool Update(List<Menu> olts)
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
        /// 根据编号删除Menu，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new Menu { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除Menu，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(Menu obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<Menu>(obj);
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
        /// 删除Menu集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<Menu> objs)
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
        /// 根据编号删除Menu，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new Menu { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除Menu，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(Menu obj)
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
        /// 根据编号删除Menu，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<Menu> objs)
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
        /// 获取Menu集合
        /// </summary>
        /// <returns>返回Menu集合</returns>
        public List<Menu> GetMenus()
        {
            List<Menu> objs = os.GetObjects<Menu>(new Menu() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Menu集合</returns>
        public List<Menu> GetMenus(Menu obj)
        {
            obj.IsDeleted = false;

            List<Menu> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回Menu集合</returns>
        public List<Menu> GetMenus(Menu obj, string where)
        {
            obj.IsDeleted = false;

            List<Menu> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Menu集合</returns>
        public List<Menu> GetMenus(Menu obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<Menu> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回Menu集合</returns>
        public List<Menu> GetMenus(Menu obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<Menu> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回Menu集合</returns>
        public PagedList<Menu> GetMenus(int pageIndex, int pageCount)
        {
            PagedList<Menu> objs = os.GetObjects(new Menu() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Menu集合</returns>
        public PagedList<Menu> GetMenus(Menu obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<Menu> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Menu集合</returns>
        public PagedList<Menu> GetMenus(string sql, int pageIndex, int pageCount)
        {
            PagedList<Menu> objs = os.GetObjects<Menu>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回Menu集合</returns>
        public PagedList<Menu> GetMenus(Menu obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<Menu> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Menu集合</returns>
        public PagedList<Menu> GetMenus(Menu obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Menu> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取Menu集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Menu集合</returns>
        public PagedList<Menu> GetMenus(Menu obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Menu> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取Menu
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Menu</returns>
        public Menu GetMenu(Menu obj)
        {
			obj.IsDeleted = false;
			
            Menu entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取Menu
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回Menu</returns>
        public Menu GetMenu(int id)
        {
            Menu entity = os.GetObject(new Menu { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class MenuService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public MenuService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public MenuService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}