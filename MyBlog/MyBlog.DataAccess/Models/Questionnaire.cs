using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.DataAccess.Models
{
    public class Questionnaire
    {
        public Int32 QuestionnaireId { get; set; }
        public String Country { get; set; }
        public Int32 Rate { get; set; }
        public List<String> Favourites { get; set; } = new List<string>();
        public String Word { get; set; }
    }
}