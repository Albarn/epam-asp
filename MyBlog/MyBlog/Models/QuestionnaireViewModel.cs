using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class QuestionnaireViewModel
    {
        [Required]
        [RadioItems(new[] { Questionnaire.Country1,Questionnaire.Country2,Questionnaire.Country3 })]
        public String Country { get; set; }

        [Required]
        [Range(1,5)]
        public Int32 Rate { get; set; }

        [CheckBoxItems(new[] { Questionnaire.Favourite1,Questionnaire.Favourite2,Questionnaire.Favourite3 })]
        public IEnumerable<String> Favourites { get; set; }

        [Required]
        public String Word { get; set; }
    }
}