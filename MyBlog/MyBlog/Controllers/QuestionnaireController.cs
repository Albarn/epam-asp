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
    public class QuestionnaireController : Controller
    {
        private QuestionnaireRepository questionnaires = new QuestionnaireRepository();

        public ActionResult Index()
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

        public ActionResult Add(QuestionnaireViewModel model)
        {
            //select list items for inputs
            ViewBag.Countries = Questionnaire
                .CountriesList
                .Select(c => new SelectListItem() { Text = c, Value = c });
            ViewBag.Favourites = Questionnaire
                .FavouritesList
                .Select(f => new SelectListItem() { Text = f, Value = f });

            if (HttpContext.Request.HttpMethod == "GET")
            {
                //it's get method, so
                //there aint any errors in model
                ModelState.Clear();
                return View();
            }
            else if (HttpContext.Request.HttpMethod=="POST")
            {
                //validate model and record it to repository
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                Questionnaire q = new Questionnaire()
                {
                    Country = model.Country,
                    Favourites = model.Favourites,
                    Rate = model.Rate,
                    Word = model.Word
                };
                questionnaires.Add(q);
                return View("AddResult", model);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}