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
            //1. add article without tags
            var tags = entity.Tags.Select(t => t.TagId).ToList() ;
            entity.Tags.Clear();
            entity=db.Articles.Add(entity);
            db.SaveChanges();

            //2. add tag entries to entity
            var tagEntries = db.Tags.ToList();
            foreach(var tId in tags)
            {
                entity.Tags.Add(tagEntries.Find(t=>t.TagId==tId));
            }
            db.Entry(entity).State=EntityState.Modified;
            db.SaveChanges();
        }

        public Article Find(params object[] keyValues)
        {
            var ans=db.Articles.Find(keyValues);
            db.Entry(ans).Collection(a => a.Tags).Load();
            return ans;
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles.Include(a=>a.Tags).ToList();
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
