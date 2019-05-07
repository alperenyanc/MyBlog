using MyBlog.DAL.ORM.Entity;
using MyBlog.DAL.ORM.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Context
{
    public class ProjeContext:DbContext
    {
        public ProjeContext()
        {
               Database.Connection.ConnectionString= "Server=DESKTOP-1KMD7N2;Database=MyBlog;uid=admin2;pwd=alp123;";
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Like>Likes { get; set; }
        public DbSet<Comment>Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
