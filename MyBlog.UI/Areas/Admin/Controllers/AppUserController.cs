using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        // GET: Admin/AppUser

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

       
   


    }
}