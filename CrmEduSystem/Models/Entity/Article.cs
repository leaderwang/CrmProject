using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;

namespace Models
{
    public partial class Article
    {
        ArticleKind _ArticleKind = new ArticleKind();

        public ArticleKind ArticleKind
        {
            get
            {
                if (this.KID > 0 && (_ArticleKind == null || _ArticleKind.ID == 0))
                {
                    _ArticleKind = new ArticleKindLogic().GetArticleKind(this.KID);
                }
                if (_ArticleKind == null) _ArticleKind = new ArticleKind();
                return _ArticleKind;
            }
            set { _ArticleKind = value; }
        }
    }
}
