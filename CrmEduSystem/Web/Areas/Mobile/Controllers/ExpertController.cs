using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Models;
using MvcPager;

namespace Web.Areas.Mobile.Controllers
{
    [LoginFlagAttribute]
    public class ExpertController : Controller
    {
        ArticleLogic articleLogic = new ArticleLogic();
        MemberLogic memberLogic = new MemberLogic();
        ArticleKindLogic articleKindLogic = new ArticleKindLogic();
        // GET: /Mobile/Expert/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Conversation(int? pageIndex, int? pageSize, string keywords, string openID, string classID)
        {
            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(classID))
            {
                where.Append(" and   classid  =" + classID);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                where.Append(" and   (title like '%" + keywords + "%'or summary like '%" + keywords + "%' or keywords like '%" + keywords + "%' or [content] like '%" + keywords + "%')");
            }
            PagedList<Article> list = articleLogic.GetArticles(new Article() { KID = 11, IsDeleted = false }, "", " ReleaseDate", "desc").ToPagedList(pageIndex ?? 1, pageSize ?? 300);
            ViewBag.key = keywords;
            ViewBag.openID = openID;
            return View(list);
        }


        public ActionResult Interview(int? pageIndex, int? pageSize, string keywords, string openID, string classID)
        {
            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(classID))
            {
                where.Append(" and   classid  =" + classID);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                where.Append(" and   (title like '%" + keywords + "%'or summary like '%" + keywords + "%' or keywords like '%" + keywords + "%' or [content] like '%" + keywords + "%')");
            }
            PagedList<Article> list = articleLogic.GetArticles(new Article() { KID = 12, IsDeleted = false }, "", " ReleaseDate", "desc").ToPagedList(pageIndex ?? 1, pageSize ?? 300);
            ViewBag.key = keywords;
            ViewBag.openID = openID;
            return View(list);
        }
        /// <summary>
        /// 首次观看 专家笔谈 和 专家访谈  获得积分
        /// </summary>
        /// <param name="id"></param>
        /// <param name="openID"></param>
        /// <returns></returns>
        public ActionResult InterviewDetail(int id, string openID)
        {
            Article article = articleLogic.GetArticle(id);
            string title = articleKindLogic.GetArticleKind(article.KID).Name;

            if (article != null)
            {
                return View(article);
            }
            else
            {
                return Redirect("/mobile/ajax/signin?openid=" + openID);
            }
        }



        public ActionResult DetailConversation(int id, string openID)
        {
            Article article = articleLogic.GetArticle(id);
            
            string title = articleKindLogic.GetArticleKind(article.KID).Name;

            if (article != null)
            {
                return View(article);
            }
            else
            {
                return Redirect("/mobile/ajax/signin?openid=" + openID);
            }
        }

    }
}
