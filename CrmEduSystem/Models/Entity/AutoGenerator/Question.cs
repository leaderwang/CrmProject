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
    public partial class Question:INotifyPropertyChanged
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
        ///ExamID
        /// </summary>
        private Int32 _ExamID;
        /// <summary>
        ///ExamID
        /// </summary>
        [ColumnAttribute("ExamID", false, false, false)]
        public Int32 ExamID { get { return _ExamID;} set{_ExamID = value;OnPropertyChanged("ExamID");} } 


        /// <summary>
        ///Name
        /// </summary>
        private String _Name;
        /// <summary>
        ///Name
        /// </summary>
        [ColumnAttribute("Name", false, false, false)]
        public String Name { get { return _Name;} set{_Name = value;OnPropertyChanged("Name");} } 


        /// <summary>
        ///TypeID
        /// </summary>
        private Int32 _TypeID;
        /// <summary>
        ///TypeID
        /// </summary>
        [ColumnAttribute("TypeID", false, false, false)]
        public Int32 TypeID { get { return _TypeID;} set{_TypeID = value;OnPropertyChanged("TypeID");} } 


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


        /// <summary>
        ///Answer
        /// </summary>
        private String _Answer;
        /// <summary>
        ///Answer
        /// </summary>
        [ColumnAttribute("Answer", false, false, true)]
        public String Answer { get { return _Answer;} set{_Answer = value;OnPropertyChanged("Answer");} } 


        /// <summary>
        ///IsMultiSelect
        /// </summary>
        private Boolean? _IsMultiSelect;
        /// <summary>
        ///IsMultiSelect
        /// </summary>
        [ColumnAttribute("IsMultiSelect", false, false, true)]
        public Boolean? IsMultiSelect { get { return _IsMultiSelect;} set{_IsMultiSelect = value;OnPropertyChanged("IsMultiSelect");} } 


        /// <summary>
        ///Files
        /// </summary>
        private String _Files;
        /// <summary>
        ///Files
        /// </summary>
        [ColumnAttribute("Files", false, false, true)]
        public String Files { get { return _Files;} set{_Files = value;OnPropertyChanged("Files");} } 




    }
	#endregion
	#region 基本业务
    public partial class QuestionLogic
    {
        /// <summary>
        /// Question数据操作对象
        /// </summary>
        private QuestionService os = new QuestionService();
        /// <summary>
        /// 构造函数
        /// </summary>
        public QuestionLogic()
        {
            
        }
	    /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public QuestionLogic(DBContext obj)
        {
            os = new QuestionService(obj);
        }
        /// <summary>
        /// 添加Question
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>成功True失败False</returns>
        public bool Add(Question obj)
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
        /// 添加Question
        /// </summary>
        /// <param name="obj">添加对象</param>
        /// <returns>返回ID</returns>
        public int Create(Question obj)
        {
            try
            {
			    if (obj.ID > 0) throw new Exception("数据库已存在此数据");
                string result = os.Add(obj);
                os.Save(result);
                return Convert.ToInt32(new DBContext().ExecuteScalarSql("select max(id) from [Question]"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<Question> obj)
        {
            try
            {
                List<string> result = new List<string>();

                foreach (Question item in obj)
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
        /// 修改Question
        /// </summary>
        /// <param name="obj">修改对象</param>
        /// <returns>成功True失败False</returns>
        public bool Update(Question obj)
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
        public bool Update(List<Question> olts)
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
        /// 根据编号删除Question，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(int id)
        {
            try
            {
                string result = os.Update(new Question { ID = id, IsDeleted = true });

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 删除Question，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(Question obj)
        {
            string sql = "";
            try
            {
                var olts = os.GetObjects<Question>(obj);
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
        /// 删除Question集合，此处为逻辑删除，实为更新IsDelete字段
        /// </summary>
        /// <param name="objs">删除对象集合</param>
        /// <returns>成功True失败False</returns>
        public bool Delete(IList<Question> objs)
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
        /// 根据编号删除Question，物理删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(int id)
        {
            try
            {
                string result = os.Delete(new Question { ID = id }, false);

                return os.Save(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		/// <summary>
        /// 根据编号删除Question，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(Question obj)
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
        /// 根据编号删除Question，物理删除
        /// </summary>
        /// <param name="obj">查询条件对象</param>
        /// <returns>成功True失败False</returns>
        public bool Remove(IList<Question> objs)
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
        /// 获取Question集合
        /// </summary>
        /// <returns>返回Question集合</returns>
        public List<Question> GetQuestions()
        {
            List<Question> objs = os.GetObjects<Question>(new Question() { IsDeleted = false });

            return objs;
        }
        /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Question集合</returns>
        public List<Question> GetQuestions(Question obj)
        {
            obj.IsDeleted = false;

            List<Question> objs = os.GetObjects(obj);

            return objs;
        }
		 /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <returns>返回Question集合</returns>
        public List<Question> GetQuestions(Question obj, string where)
        {
            obj.IsDeleted = false;

            List<Question> objs = os.GetObjects(obj, where);

            return objs;
        }
        /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Question集合</returns>
        public List<Question> GetQuestions(Question obj,string where, string order)
        {
            obj.IsDeleted = false;

            List<Question> objs = os.GetObjects(obj, where, order,string.Empty);

            return objs;
        }
		/// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <param name="where">特殊条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="orderbyType">排序类型</param>
        /// <returns>返回Question集合</returns>
        public List<Question> GetQuestions(Question obj, string where,string order,string by)
        {
            obj.IsDeleted = false;

            List<Question> objs = os.GetObjects(obj, where, order,by);

            return objs;
        }
        /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <returns>返回Question集合</returns>
        public PagedList<Question> GetQuestions(int pageIndex, int pageCount)
        {
            PagedList<Question> objs = os.GetObjects(new Question() { IsDeleted = false }, pageIndex, pageCount);

            return objs;
        }
        /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Question集合</returns>
        public PagedList<Question> GetQuestions(Question obj, int pageIndex, int pageCount)
        {
            obj.IsDeleted = false;

            PagedList<Question> objs = os.GetObjects(obj,pageIndex, pageCount);

            return objs;
        }
		/// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Question集合</returns>
        public PagedList<Question> GetQuestions(string sql, int pageIndex, int pageCount)
        {
            PagedList<Question> objs = os.GetObjects<Question>(sql, pageIndex, pageCount);
            return objs;
        }
        /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="where">自定义查询条件</param>
        /// <returns>返回Question集合</returns>
        public PagedList<Question> GetQuestions(Question obj, int pageIndex, int pageCount, string where)
        {
            obj.IsDeleted = false;

            PagedList<Question> objs = os.GetObjects(obj, pageIndex, pageCount, where);

            return objs;
        }
		 /// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Question集合</returns>
        public PagedList<Question> GetQuestions(Question obj, int pageIndex, int pageCount, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Question> objs = os.GetObjects(obj, pageIndex, pageCount, string.Empty, order,by);

            return objs;
        }
		/// <summary>
        /// 获取Question集合
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageCount">每页多少条</param>
        /// <param name="obj">查询条件</param>
        ///  <param name="orderby">排序</param>
        /// <returns>返回Question集合</returns>
        public PagedList<Question> GetQuestions(Question obj, int pageIndex, int pageCount,string where, string order, string by)
        {
            obj.IsDeleted = false;

            PagedList<Question> objs = os.GetObjects(obj, pageIndex, pageCount, where, order, by);

            return objs;
        }
        /// <summary>
        /// 获取Question
        /// </summary>
        /// <param name="obj">查询条件</param>
        /// <returns>返回Question</returns>
        public Question GetQuestion(Question obj)
        {
			obj.IsDeleted = false;
			
            Question entity = os.GetObject(obj);

            return entity;
        }
        /// <summary>
        /// 根据编号获取Question
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回Question</returns>
        public Question GetQuestion(int id)
        {
            Question entity = os.GetObject(new Question { ID = id, IsDeleted = false });

            return entity;
        }

    }
	#endregion

	#region 基本数据库访问
    internal partial class QuestionService : EntityService
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public QuestionService()
        {
            db = new DBContext();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">操作数据库对象</param>
        public QuestionService(DBContext obj)
        {
            db = obj;
        }
      
    }
	#endregion
}