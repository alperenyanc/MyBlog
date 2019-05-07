using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Map
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.category");
            Property(x => x.CategoryName).IsOptional();
            Property(x => x.Description).IsOptional();

            HasMany(x => x.Articles)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
