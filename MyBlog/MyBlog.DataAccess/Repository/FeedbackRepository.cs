using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Repository
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        private MyBlogContext db = MyBlogContext.Create();

        public void Add(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();
        }

        public Feedback Find(params object[] keyValues)
        {
            return db.Feedbacks.Find(keyValues);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return db.Feedbacks.ToList();
        }

        public void Remove(Feedback entity)
        {
            db.Feedbacks.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Feedback entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
