using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Author.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Author/Home
        public ActionResult Index()
        {

            var model = service.ArticleService.GetActive().OrderByDescending(x => x.AddDate).Take(5);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }
            AppUser appuser = new AppUser();
            appuser = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            if (appuser.Role==DAL.ORM.Enum.Role.Author)
            {
                TempData["class"] = "custom-show";
                //return Redirect("/Author/Home/Index");
            }

            return View(model);
        }
    }
}