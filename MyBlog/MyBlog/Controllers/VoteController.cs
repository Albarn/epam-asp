using MyBlog.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class VoteController : Controller
    {
        private VoteRepository votes = new VoteRepository();

        [HttpPost]
        public ActionResult Vote(int vote)
        {
            votes.Add(new DataAccess.Models.Vote()
            {
                ArticleId = vote
            });
            Response.Cookies.Add(new HttpCookie("voted"));
            return RedirectToAction("Index","Home");
        }
    }
}