using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public enum FavouritePage
    {
        Main,
        Feedback,
        Questionnaire
    }

    public class Questionnaire
    {
        [Required]
        public String Country { get; set; }

        [Required]
        [Range(1,5)]
        public Int32 Rate { get; set; }

        [Required]
        [Range(0,2)]
        public Int32 Favourites { get; set; }

        [Required]
        public String Word { get; set; }
    }
}