using MyBlog.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Author.Controllers
{
    public class BaseController : Controller
    {

        protected EntityService service;
        // GET: Author/Base
        public BaseController()
        {
            service = new EntityService();
        }
       
    }
}