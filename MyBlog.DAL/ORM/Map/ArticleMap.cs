using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Map
{
    public class ArticleMap:CoreMap<Article>
    {
        public ArticleMap()
        {
            ToTable("dbo.Article");
            Property(x => x.Header).IsOptional();
            Property(x => x.Content).IsOptional();
            Property(x => x.PublishDate).IsOptional();

            HasMany(x => x.Likes)
                .WithRequired(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .WillCascadeOnDelete(false);
            HasMany(x => x.Comments)
                .WithRequired(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.AppUser)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
