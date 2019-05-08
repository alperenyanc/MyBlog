using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Author.Models.VM
{
    public class CommentVM
    {
        public Guid ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}