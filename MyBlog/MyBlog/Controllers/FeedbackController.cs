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
    public class FeedbackController : Controller
    {
        private FeedbackRepository feedbacks = new FeedbackRepository();

        public ActionResult Index()
        {
            return View(feedbacks
                .GetAll()
                .Select(f => new FeedbackViewModel()
                {
                    Author = f.Author,
                    Date = f.Date,
                    Text = f.Text
                }));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Feedback feedback = new Feedback()
            {
                Author = model.Author,
                Date = model.Date,
                Text = model.Text
            };
            feedbacks.Add(feedback);
            return RedirectToAction("Index");
        }
    }
}