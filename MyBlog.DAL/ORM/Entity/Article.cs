using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.ORM.Entity
{
    public class Article:BaseEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime? PublishDate { get; set; }

        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Like>Likes { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}
