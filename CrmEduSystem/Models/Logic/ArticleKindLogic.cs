using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;
using Common;

namespace Models
{
    /// <summary>
    /// 自定义ArticleKind处理类
    /// </summary>
    public partial class ArticleKindLogic
    {
        public List<ArticleKind> GetListByPID(int pid)
        {
            return this.GetArticleKinds(new ArticleKind() { PID = pid });
        }

        public bool HasChilds(int id)
        {
            bool hasChilds = false;
            try
            {
                var klts = this.GetListByPID(this.GetArticleKind(id).ID);
                if (klts != null && klts.Count > 0) hasChilds = true;
            }
            catch { }
            return hasChilds;
        }

        public List<int> GetListByName(string name)
        {
            try
            {
                return os.GetObjects<ArticleKind>("select * from [ArticleKind] where [Name] like '%" + name + "%'").Select(b => b.ID).ToList();
            }
            catch { }
            return null;
        }
    }
}
