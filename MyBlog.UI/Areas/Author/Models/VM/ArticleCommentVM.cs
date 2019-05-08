using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Author.Models.VM
{
    public class ArticleCommentVM
    {
        public ArticleCommentVM()
        {
            Comments = new List<Comment>();
        }
        public Article Article { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int Likes { get; set; }
    }
}