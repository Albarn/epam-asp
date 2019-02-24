using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Repository
{
    public class TagRepository : IRepository<Tag>
    {
        private MyBlogContext db = new MyBlogContext();
        public void Add(Tag entity)
        {
            db.Tags.Add(entity);
            db.SaveChanges();
        }

        public Tag Find(params object[] keyValues)
        {
            return db.Tags.Find(keyValues);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.ToList();
        }

        public void Remove(Tag entity)
        {
            db.Tags.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Tag entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
