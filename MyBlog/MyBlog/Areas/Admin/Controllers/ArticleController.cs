using MyBlog.Areas.Admin.Models;
using MyBlog.DataAccess.Models;
using MyBlog.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class ArticleController : Controller
    {
        private IRepository<Article> articles = new ArticleRepository();
        private IRepository<Tag> tags = new TagRepository();
        // GET: Admin/Article
        public ActionResult Index()
        {
            return View("Index",articles
                .GetAll()
                .Select(a => new ArticleItemViewModel()
                {
                    Date = a.Date,
                    Tags = a.Tags,
                    Text = a.Text,
                    Title = a.Title
                }));
        }
        
        public ActionResult Create()
        {
            ViewBag.Tags = tags
                .GetAll()
                .ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var a = new Article()
            {
                Date = DateTime.Now,
                Text = model.Text,
                Tags=model.Tags.Select(t=>new Tag() { TagId=t}).ToList(),
                Title = model.Title
            };
            articles.Add(a);

            return RedirectToAction("Index") ;
        }
    }
}