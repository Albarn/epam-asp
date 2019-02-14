﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class ArticleViewModel
    {
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
        public int Id { get; set; }
    }
}