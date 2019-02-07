using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.DataAccess.Models
{
    public class Feedback
    {
        public Int32 FeedbackId { get; set; }
        public String Author { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
    }
}