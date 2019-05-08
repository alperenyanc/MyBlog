using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models;
using MyBlog.UI.Areas.Admin.Models.DTO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {


        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category data)
        {
            service.CatetegoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }
        public ActionResult List()
        {
            List<Category> model = service.CatetegoryService.GetActive();
            return View(model);/// index koyup denencek.
        }
        public ActionResult Update(Guid id)
        {
            Category cat = service.CatetegoryService.GetById(id);
            CategoryDTO model = new CategoryDTO();
            model.ID = cat.ID;
            model.CategoryName = cat.CategoryName;
            model.Description = cat.Description;
            return View(model);


        }
        [HttpPost]
        public ActionResult Update(CategoryDTO data)
        {
            Category cat = service.CatetegoryService.GetById(data.ID);
            cat.CategoryName = data.CategoryName;
            cat.Description = data.Description;
            service.CatetegoryService.Update(cat);
            return Redirect("/Admin/Category/List");
        }
        public ActionResult Delete(Guid id)
        {
            service.CatetegoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }


    }
        
}