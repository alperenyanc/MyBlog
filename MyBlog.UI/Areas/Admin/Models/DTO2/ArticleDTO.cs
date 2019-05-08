using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.DTO2
{
    public class ArticleDTO:BaseDTO
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime? PublishDate { get; set; }

        public Guid CategoryID { get; set; }
        public Guid AppUserID { get; set; }
        // Get List!
        // article and Category - article  and appuser, we need VM--ArticleVM!
    }
}