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
        private VoteRepository votes = new VoteRepository();
        
        //returns home view with articles list
        public ActionResult Index()
        {
            //calculate vote results for users who have voted
            if (Request.Cookies.AllKeys.Contains("voted"))
            {
                //key is article name, value is number of votes
                Dictionary<String, int> results = new Dictionary<String, int>();
                foreach (var v in votes.GetAll())
                {
                    //set one as initial value
                    if (!results.ContainsKey(v.Article.Title))
                    {
                        results[v.Article.Title] = 1;
                    }
                    else
                    {
                        results[v.Article.Title]++;
                    }
                }
                var votesList = results.ToList();

                //sort votes desceding
                votesList.Sort((kv1, kv2) => kv2.Value.CompareTo(kv1.Value));
                ViewBag.Votes = votesList;
            }
            
            return View(articles
                .GetAll()
                .Select(a => new ArticleViewModel()
                {
                    Date = a.Date,
                    Text = a.Text.Length>200?a.Text.Remove(200):a.Text,
                    Title = a.Title,
                    Id=a.ArticleId
                })
                .OrderBy(a=>a.Date));
        }

        public ActionResult ArticleDetails(int? id)
        {
            if (id == null) return HttpNotFound();
            var model = articles
                .GetAll()
                .Where(a => a.ArticleId == id)
                ?.Select(a => new ArticleDetailsViewModel()
                {
                    Date = a.Date,
                    Text = a.Text,
                    Title = a.Title,
                    Tags = a.Tags.Select(t=>t.TagString).ToArray()
                })
                ?.Single();
            if (model == null) return HttpNotFound();
            return View(model);
        }
    }
}