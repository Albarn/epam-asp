using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Article
    {
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
    }

    public class Articles : List<Article>
    {
        private Articles(): base()
        { }

        private static Articles _this;
        public static Articles Instance
        {
            get
            {
                if(_this==null)
                {
                    _this = new Articles();
                }
                return _this;
            }
        }
    }
}