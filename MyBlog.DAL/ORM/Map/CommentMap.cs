using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Map
{
    public class CommentMap:CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.comment");
            Property(a => a.Header).IsRequired();
            Property(a => a.Content).IsRequired();
            Property(a => a.CommentNumber).IsOptional();

            HasKey(x => new { x.AppUserID, x.ArticleID });
        }
    }
}
