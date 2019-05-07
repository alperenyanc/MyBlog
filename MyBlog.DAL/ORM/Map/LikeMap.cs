using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Map
{
    public class LikeMap:CoreMap<Like>
    {
        public LikeMap()
        {
            ToTable("dbo.like");

         
            HasKey(x => new { x.AppUserID, x.ArticleID });
        }
    }
}
