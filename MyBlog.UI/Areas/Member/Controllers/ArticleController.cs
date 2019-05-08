using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Member/Article
        public ActionResult List()
        {
            List<Article> model = service.ArticleService.GetActive();
            return View(model);
        }
    }
}