using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Author.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName is not available!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password available!")]
        public string Password { get; set; }
    }
}