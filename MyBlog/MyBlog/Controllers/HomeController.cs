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
    //TODO: split
    public class HomeController : Controller
    {
        private ArticleRepository articles = new ArticleRepository();
        private FeedbackRepository feedbacks = new FeedbackRepository();
        private QuestionnaireRepository questionnaires = new QuestionnaireRepository();

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

        public ActionResult ViewFeedbacks()
        {
            return View(feedbacks
                .GetAll()
                .Select(f => new FeedbackViewModel()
                {
                    Author = f.Author,
                    Date = DateTime.Now,
                    Text = f.Text
                }
                    ));
        }

        public ActionResult ViewQuestionnaires()
        {
            return View(questionnaires
                .GetAll()
                .Select(q => new QuestionnaireViewModel()
                {
                    Country = q.Country,
                    Favourites = q.Favourites,
                    Rate = q.Rate,
                    Word = q.Word
                }));
        }

        [HttpGet]
        public ActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeedback(FeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Feedback feedback = new Feedback()
            {
                Author = model.Author,
                Date = DateTime.Now,
                Text = model.Text
            };
            feedbacks.Add(feedback);
            return RedirectToAction("Index");
        }

        private void InitQuestionnaire()
        {
            ViewBag.Countries = Store
                .Countries
                .Select(c => new SelectListItem() { Text = c, Value = c });
            ViewBag.Favourites = Store
                .Favourites
                .Select(f => new SelectListItem() { Text = f, Value = f });
        }

        public ActionResult AddQuestionnaire(QuestionnaireViewModel model)
        {
            InitQuestionnaire();
            if (HttpContext.Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    Questionnaire q = new Questionnaire()
                    {
                        Country = model.Country,
                        Favourites = model.Favourites,
                        Rate = model.Rate,
                        Word = model.Word
                    };
                    questionnaires.Add(q);
                    return View("QResult", model);
                }
                ViewBag.NoErrors = false;
                return View(model);
            }

            ViewBag.NoErrors = true;
            return View();
        }
    }
}