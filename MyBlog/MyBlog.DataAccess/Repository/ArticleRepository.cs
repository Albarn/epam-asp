using MyBlog.DataAccess.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyBlog.DataAccess.Repository
{
    public class ArticleRepository : IRepository<Article>
    {
        private MyBlogContext db = MyBlogContext.Create();

        public void Add(Article entity)
        {
            db.Articles.Add(entity);
            db.SaveChanges();
        }

        public Article Find(params object[] keyValues)
        {
            return db.Articles.Find(keyValues);
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles.ToList();
        }

        public void Remove(Article entity)
        {
            db.Articles.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Article entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
