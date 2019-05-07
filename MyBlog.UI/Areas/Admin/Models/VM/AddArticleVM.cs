using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.VM
{
    public class AddArticleVM:BaseVM
    {
        public AddArticleVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }

        // we get list AppUsers and categories in Article, Because Article have must categories and AppUsers.
    }
}