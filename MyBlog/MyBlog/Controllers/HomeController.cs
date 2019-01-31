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
        public ActionResult Index()
        {
            return View(Articles.Instance);
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(Feedback model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        private void InitQuestionnaire()
        {
            var countries = new List<SelectListItem>();
            foreach (String country in Countries.Instance)
            {
                countries.Add(new SelectListItem() { Text = country, Value = country });
            }
            ViewBag.Countries = countries;
            var favourites = new List<String>();
            favourites.AddRange(new[] { "Main", "Feedback", "Questionnaire" });
            ViewBag.Favourites = favourites;
        }

        public ActionResult Questionnaire(Questionnaire model)
        {
            InitQuestionnaire();
            if (HttpContext.Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Result = "Thanks for answers, your rate was:" + model.Rate;
                    return View("QResult");
                }
                ViewBag.NoErrors = false;
                return View(model);
            }
            

            ViewBag.NoErrors = true;
            return View();
        }
    }
}