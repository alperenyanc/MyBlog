using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models;
using MyBlog.UI.Areas.Admin.Models.DTO2;
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

        [HttpPost]
        public ActionResult Add(AppUser data)
        {
            service.AppUserService.Add(data);
            return Redirect("/Admin/AppUser/List");
        }
    
        public ActionResult List()
        {
            List<AppUser> model = service.AppUserService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            AppUser user = service.AppUserService.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.Password = user.Password;
            model.UserName = user.Password;
            model.Role = user.Role;
            model.LastName = user.LastName;
            return View(model);


        }
        [HttpPost]
        public ActionResult Update(AppUserDTO data)
        {
            AppUser user = service.AppUserService.GetById(data.ID);
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.UserName = data.UserName;
            user.Password = data.Password;
            user.Email = data.Email;
            user.Role = data.Role;
            service.AppUserService.Update(user);
            return Redirect("/Admin/AppUser/List");
        }
        public ActionResult Delete(Guid id)
        {
            service.AppUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
       
   


    }
}