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
            return View(Store.Articles);
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
            ViewBag.Countries = Store
                .Countries
                .Select(c => new SelectListItem() { Text = c, Value = c });
            ViewBag.Favourites = Store
                .Favourites
                .Select(f => new SelectListItem() { Text = f, Value = f });
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