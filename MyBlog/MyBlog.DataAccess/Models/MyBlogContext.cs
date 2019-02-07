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
        static MyBlogContext()
        {
            Database.SetInitializer(new MyBlogInitializer());
        }

        public MyBlogContext(String nameOrConnectionString="Default"):base(nameOrConnectionString)
        {
        }

        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Questionnaire> Questionnaires { get; set; }
    }
}
