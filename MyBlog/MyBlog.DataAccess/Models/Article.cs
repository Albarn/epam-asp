using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.DataAccess.Models
{
    public class Article
    {
        public Int32 ArticleId { get; set; }
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
        public IList<Tag> Tags { get; set; } = new List<Tag>();
    }
}