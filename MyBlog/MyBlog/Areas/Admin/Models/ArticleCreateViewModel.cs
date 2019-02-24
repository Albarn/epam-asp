using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Areas.Admin.Models
{
    public class ArticleCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public IEnumerable<int> Tags { get; set; } = new List<int>();
    }
}