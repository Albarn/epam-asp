using MyBlog.DataAccess.Models;
using MyBlog.DataAccess.Repository;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private ArticleRepository articles = new ArticleRepository();

        //returns home view with articles list
        public ActionResult Index()
        {
            return View(articles
                .GetAll()
                .Select(a => new ArticleViewModel()
                {
                    Date = a.Date,
                    Text = a.Text,
                    Title = a.Title
                }));
        }
    }
}