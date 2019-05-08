using MyBlog.DAL.ORM.Entity;
using MyBlog.DAL.ORM.Enum;
using MyBlog.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.UI.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.FindByUserName(User.Identity.Name);
                if (user.Status == Status.Active || user.Status == Status.Updated)
                {
                    if (user.Role == Role.Admin)
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        return Redirect("/Admin/Home/Index");
                    }
                    else if (user.Role == Role.Author)
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        return Redirect("/Author/Home/Index");
                    }
                    else
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        return Redirect("/Member/Home/Index");
                    }
                }
                else
                {
                    ViewData["error"] = "Username or Password is wrong!";
                    return View();
                }
            }
            else
            {
                TempData["class"] = "custom-hide";
                return View();
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credential)
        {
            if (ModelState.IsValid)
            {
                if (service.AppUserService.CheckCredentials(credential.UserName, credential.Password))
                {
                    AppUser user = service.AppUserService.FindByUserName(credential.UserName);
                    if (user.Status == Status.Active || user.Status == Status.Updated)
                    {
                        if (user.Role == Role.Admin)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            return Redirect("/Admin/Home/Index");
                        }
                        else if (user.Role == Role.Author)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            return Redirect("/Author/Home/Index");
                        }
                        else
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            return Redirect("/Member/Home/Index");
                        }
                    }
                    else
                    {
                        ViewData["error"] = "Username or Password is wrong!";
                        return View();
                    }

                }
                else
                {
                    ViewData["error"] = "Username or Password is wrong!";
                    return View();
                }
            }
            else
            {
                TempData["class"] = "custom-hide";
                return View();
            }
        }
        [Authorize]//Login olmuş kullanıcılar için
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}