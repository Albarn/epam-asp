using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public static class Store
    {
        private static List<String> countries;
        private static List<String> favourites;

        public static IEnumerable<String> Countries { get => countries.Select(s => s); }
        public static IEnumerable<String> Favourites { get => favourites.Select(s => s); }

        static Store()
        {
            countries = new List<String>(new[] { "Ukraine", "Zenonia", "Nortrend" });
            favourites = new List<String>(new[] { "Home", "Feedback", "Questionnaire" });
        }
    }
}