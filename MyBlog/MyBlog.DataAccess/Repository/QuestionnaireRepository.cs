using MyBlog.DataAccess.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyBlog.DataAccess.Repository
{
    public class QuestionnaireRepository : IRepository<Questionnaire>
    {
        private MyBlogContext db = MyBlogContext.Create();

        public void Add(Questionnaire entity)
        {
            db.Questionnaires.Add(entity);
            db.SaveChanges();
        }

        public Questionnaire Find(params object[] keyValues)
        {
            return db.Questionnaires.Find(keyValues);
        }

        public IEnumerable<Questionnaire> GetAll()
        {
            return db.Questionnaires.ToList();
        }

        public void Remove(Questionnaire entity)
        {
            db.Questionnaires.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Questionnaire entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
