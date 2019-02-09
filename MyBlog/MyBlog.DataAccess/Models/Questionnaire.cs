using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.DataAccess.Models
{
    public class Questionnaire
    {
        //possible countries and favourites samples
        public const String Country1 = "Ukraine";
        public const String Country2 = "Zenonia";
        public const String Country3 = "Nortrend";
        public static String[] CountriesList { get => new[] { Country1, Country2, Country3 }; }
        public const String Favourite1 = "Home";
        public const String Favourite2= "Feedback";
        public const String Favourite3 = "Questionnaire";
        public static String[] FavouritesList { get => new[] { Favourite1, Favourite2, Favourite3 }; }

        public Int32 QuestionnaireId { get; set; }
        public String Country { get; set; }
        public Int32 Rate { get; set; }
        public string FavouritesString { get; set; }
        [NotMapped]
        public IEnumerable<String> Favourites
        {
            get => FavouritesString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            set => FavouritesString = value.Aggregate((s1, s2) => s1 + "," + s2);
        }
        public String Word { get; set; }
    }
}