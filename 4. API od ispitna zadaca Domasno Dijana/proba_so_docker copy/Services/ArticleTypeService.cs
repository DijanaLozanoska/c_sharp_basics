using proba_so_docker.Data;
using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace proba_so_docker.Services
{
    public class ArticleTypeService : IArticleTypeService
    {
        private readonly IApplicationDbContext db;
        public ArticleTypeService(IApplicationDbContext db)
        {
            this.db = db;
        }


        public List<ArticleType> Get()
        {
            return db.ArticleType.ToList(); // select * from article
        }


        public ArticleType Get(string value)
        {
            var article = db.ArticleType.FirstOrDefault(at => at.Value == value); // select * from article where articletype='111'
            return article;  // ctrl+enter na query  
        }


        public ArticleType Add(ArticleType a)
        {
            var articleType = db.ArticleType.Add(a); // insert into stella_12c_test_test.articletype (id, value, a)
            db.SaveChanges();
            return articleType.Entity;
        }
  

        public bool Delete(int id)
        {
            var type = db.ArticleType.FirstOrDefault(f => f.Id == id); // select articletype from article 
            db.ArticleType.Remove(type); // delete article where articletype='journal'
            var changesCount = db.SaveChanges();  // commit or rollback 
            return changesCount == 1; // select count(dis
        }


        public ArticleType Get(int id)
        {
            return db.ArticleType.FirstOrDefault(x => x.Id == id);
        }

        public ArticleType Update(ArticleType at)
        {
            var updatedArticleType = db.ArticleType.Update(at); // update article, set article="djiana" where articleid=1122
            db.SaveChanges(); // commit or rollback 
            return updatedArticleType.Entity; // ctrl+enter na query  
        }
    }
}
