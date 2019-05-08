using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Author.Models.DTO;
using MyBlog.UI.Areas.Author.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Author.Controllers
{
    public class ArticleController : BaseController
    {
        private object comment;

        public ActionResult Add()
        {
            return View(service.CatetegoryService.GetActive());
        }
        [HttpPost]
        public ActionResult Add(Article data)
        {
            AppUser user = service.AppUserService.GetByDefault(x => x.UserName == User.Identity.Name);
       
            data.AppUserID = user.ID;
            data.PublishDate = DateTime.Now;
            service.ArticleService.Add(data);
            return Redirect("/Author/Article/List");

        }
        public ActionResult List()
        {
            Guid userid = service.AppUserService.FindByUserName(User.Identity.Name).ID;
            List<Article> model = service.ArticleService.GetDefault(x => x.AppUserID == userid && (x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Updated));
            return View(model);
        }
        public ActionResult Update(Guid id)
        {
            Article article = service.ArticleService.GetById(id);
            UpdateArticleVM model = new UpdateArticleVM();
            model.Article.ID = article.ID;
            model.Article.Header = article.Header;
            model.Article.Content = article.Content;
            model.Article.PublishDate = DateTime.Now;
            List<Category> categoriesmodel = service.CatetegoryService.GetActive();
            model.Categories = categoriesmodel;
            return View(model);


        }
        [HttpPost]
        public ActionResult Update(ArticleDTO data)
        {
            Article article = service.ArticleService.GetById(data.ID);
            article.Header = data.Header;
            article.Content = data.Content;
            article.PublishDate = data.PublishDate;
            article.UpdateDate = DateTime.Now;
            article.Status = DAL.ORM.Enum.Status.Updated;
            article.CategoryID = data.CategoryID;
            service.ArticleService.Update(article);
            return Redirect("/Author/Article/List");

        }
        public ActionResult Delete(Guid id)
        {
            service.ArticleService.Remove(id);
            return Redirect("/Author/Article/List");
        }
        public ActionResult Show(Guid id)
        {
            ArticleCommentVM model = new ArticleCommentVM();
            model.Article = service.ArticleService.GetById(id);
            model.Comments = service.CommentService.GetDefault(x => x.ArticleID == id).OrderByDescending(x => x.AddDate).Take(10);
            model.Likes = service.LikeService.GetDefault(z => z.ArticleID == id).Count();
            return View(model);

        }
        public ActionResult AddComment(CommentVM data)
        {
            Comment comment = new Comment();
            comment.AppUserID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            comment.ArticleID = data.ID;
            comment.Content = data.Content;
            comment.AddDate = DateTime.Now;
            service.CommentService.Add(comment);
            return Redirect("/Article/Show/" + data.ID);
        }
        public JsonResult AddLike(Guid id)
        {
            JsonLikeVM jt = new JsonLikeVM();
            Guid appUserID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID;

            if (!(service.LikeService.Any(x => x.AppUserID == appUserID && x.ArticleID == id)))
            {
                Like like = new Like();
                like.ArticleID = id;
                like.AppUserID = appUserID;
                service.LikeService.Add(like);

                jt.Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count();
                jt.UserMessage = "Bu yazıyı daha önce beğendiniz";
                jt.Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count();
                return Json(jt, JsonRequestBehavior.AllowGet);
            }
            return Json(jt, JsonRequestBehavior.DenyGet);

        }



        //public ActionResult Show(Article data)
        //{
        //    AppUser user = service.AppUserService.GetByDefault(x => x.UserName == User.Identity.Name);
        //    List<Article> model = service.ArticleService.GetDefault(x => x.AppUserID != user.ID);
        //    return View(model);
        //}



    }
}