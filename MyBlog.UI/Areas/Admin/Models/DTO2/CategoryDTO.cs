using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.DTO2
{
    public class CategoryDTO:BaseDTO
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}