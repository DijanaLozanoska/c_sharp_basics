using System;
using proba_so_docker.Data;
using proba_so_docker.Entities;
using proba_so_docker.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using proba_so_docker.Models;
using Microsoft.EntityFrameworkCore;

namespace proba_so_docker.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IApplicationDbContext db;
        private readonly IArticleTypeService _articleTypeService;

        public ArticleService(IApplicationDbContext db, IArticleTypeService articleTypeService)
        {
            this.db = db;
            _articleTypeService = articleTypeService;
        }


        public List<Article> GetByStudentId(int studentId)
        {
            return db.Article.Where(x => x.StudentId == studentId).ToList();
        }


        public List<Article> Get()
        {
            return db.Article.ToList(); // select * from article
        } 


        public Article Get(int id)
        {
            return db.Article.FirstOrDefault(x => x.Id == id); // select * from article where id=1122
        }  


        public Article Add(Article a)
        {
            var addedArticle = db.Article.Add(a); // insert into stella_12c_test_test.article (id,title,publishyear,studentid,facultyid,typeid) values ( value1, value2, value3, value4, value5, value6)
            db.SaveChanges(); // commit or rollback 
            return addedArticle.Entity; // ctrl+enter na query  
        } 


        public Article Update(Article a)
        {
            var updatedArticle = db.Article.Update(a); // update article, set article="djiana" where articleid=1122
            db.SaveChanges(); // commit or rollback 
            return updatedArticle.Entity; // ctrl+enter na query  
        }


        public bool Delete(int id)
        {
            if (id < 0)
            throw new Exception("<0"); 
            var type = db.ArticleType.FirstOrDefault(f => f.Id == id); // select articletype from article 
            db.ArticleType.Remove(type); // delete article where articletype='journal'
            var changesCount = db.SaveChanges();  // commit or rollback 
            return changesCount == 1; // select count(distinct articletypeid) from article where trunc(sysdate)="03-mar-2021"
        }

        
        public double PHDArticleRang(List<Article> articles)
        {
            var rang = 0;
            foreach (var article in articles)  // For-Each Loop
            {
                if (article.Type.Value.ToLower() == "conference") // select articleid, articletype from article where articletype != lower(articletype)  and articletypeid=1
                {
                    rang += 1; // update article , set rang = rang + 1 
                }
                if (article.Type.Value.ToLower() == "journal") // select articleid, articletype from article where articletype != lower(articletype)  and articletypeid=2
                {
                    rang += 3; // update article , set rang = rang + 3 
                }
            }
            return rang; // ctrl+enter na query  
        }


        public ArticleCountResponse CountArticle(List<Article> articles, ArticleCountRequest request)
        {
            var conferenceArticles = 0;
            var journalArticles = 0;
            foreach (var article in articles)
            {
                if (article.Type.Value.ToLower() == "conference")
                {
                    conferenceArticles++;
                }
                if (article.Type.Value.ToLower() == "journal")
                {
                    journalArticles++;
                }
            }

            return null;
        }


        public (int ConferenceCount, int JournalCount) CountArticlesByType(List<Article> articles)
        {
            var confCount = 0;
            var journalCount = 0;
            foreach (var article in articles)
            {
                if (article.Type.Value.ToLower() == "conference")
                {
                    confCount += 1;
                }
                if (article.Type.Value.ToLower() == "journal")
                {
                    journalCount += 3;
                }
            }
            return (confCount, journalCount);
        }
    }
}
