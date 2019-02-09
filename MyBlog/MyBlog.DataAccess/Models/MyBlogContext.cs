using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Models
{
    internal class MyBlogContext : DbContext
    {
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Questionnaire> Questionnaires { get; set; }

        static MyBlogContext()
        {
            Database.SetInitializer(new MyBlogInitializer());
        }

        public MyBlogContext(String nameOrConnectionString="Default")
            :base(nameOrConnectionString)
        { }

        private static MyBlogContext instance;
        public static MyBlogContext Create()
        {
            if (instance == null) instance = new MyBlogContext();
            return instance;
        }
    }
}
