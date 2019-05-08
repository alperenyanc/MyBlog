using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            TempData["class"] = "custom-hide";
            var model = service.ArticleService.GetActive().OrderByDescending(x => x.AddDate).Take(5);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }

            AppUser appuser = new AppUser();
            appuser = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            if (appuser.Role == DAL.ORM.Enum.Role.Member)
            {
                TempData["class"] = "custom-show";
                // return Redirect("/Member/Home/Index");
            }
            return View(model);
        }
    }
}