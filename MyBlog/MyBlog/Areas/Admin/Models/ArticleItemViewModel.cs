using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Areas.Admin.Models
{
    public class ArticleItemViewModel
    {
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}