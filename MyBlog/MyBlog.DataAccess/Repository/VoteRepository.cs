using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Repository
{
    public class VoteRepository : IRepository<Vote>
    {
        private MyBlogContext db = MyBlogContext.Create();
        public void Add(Vote entity)
        {
            db.Votes.Add(entity);
            db.SaveChanges();
        }

        public Vote Find(params object[] keyValues)
        {
            return db.Votes.Find(keyValues);
        }

        public IEnumerable<Vote> GetAll()
        {
            return db.Votes.Include(v=>v.Article).ToList();
        }

        public void Remove(Vote entity)
        {
            db.Votes.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Vote entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
