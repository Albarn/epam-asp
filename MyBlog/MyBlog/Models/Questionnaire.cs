using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Questionnaire
    {
        [Required]
        [RadioItems(new[] { "Ukraine", "Zenonia", "Nortrend" })]
        public String Country { get; set; }

        [Required]
        [Range(1,5)]
        public Int32 Rate { get; set; }

        [Required]
        [CheckBoxItems(new[] { "Home", "Feedback", "Questionnaire" })]
        public List<String> Favourites { get; set; }

        [Required]
        public String Word { get; set; }
    }
}