using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.VM
{
    public class UpdateArticleVM:BaseVM
    {
        // Article update= categories update+appusers update+article update so 
        public UpdateArticleVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
            Article = new ArticleDTO(); // Article DTO = Header + content !
        }
        // we gotta get list Appusers , categories and headle + content so
        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
        public ArticleDTO Article { get; set; }
    }
}