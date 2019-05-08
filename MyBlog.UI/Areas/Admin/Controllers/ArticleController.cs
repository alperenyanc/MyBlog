using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models;
using MyBlog.UI.Areas.Admin.Models.DTO2;
using MyBlog.UI.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {

        public ActionResult Add()
        {
            AddArticleVM model = new AddArticleVM()
            {  // articleVM have 2 table

                Categories = service.CatetegoryService.GetActive(),
                AppUsers = service.AppUserService.GetActive(),


            };
            return View(model);

        }
        [HttpPost]
        public ActionResult Add(Article data)
        {
            data.PublishDate = DateTime.Now;
            service.ArticleService.Add(data);
            return Redirect("/Admin/Article/List");
        }
        public ActionResult List()
        {
            List<Article> model = service.ArticleService.GetActive();
            return View(model);
        }
        public ActionResult Update(Guid id)
        {
            // we need UpdateArticle VM---

            UpdateArticleVM model = new UpdateArticleVM();
            Article article = service.ArticleService.GetById(id);
            // first service to model:
            model.Article.ID = article.ID;
            model.Article.Header = article.Header;
            model.Article.Content = article.Content;
            model.Article.PublishDate = DateTime.Now;
            

            model.Categories = service.CatetegoryService.GetActive();
            model.AppUsers = service.AppUserService.GetActive();
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Update(ArticleDTO data)
        {
            // secont data to service
            Article article = service.ArticleService.GetById(data.ID);
            article.Header = data.Header;
            article.Content = data.Content;

            article.CategoryID = data.CategoryID;
            article.AppUserID = data.AppUserID;
            service.ArticleService.Update(article);

            return Redirect("/Admin/Article/List");

        }
        public ActionResult Delete(Guid id)
        {
            service.ArticleService.Remove(id);
            return Redirect("/Admin/Article/List");
        }


       
        
    }
}