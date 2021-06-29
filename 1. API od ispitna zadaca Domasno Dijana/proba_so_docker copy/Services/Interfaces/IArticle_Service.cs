using proba_so_docker.Entities;
using proba_so_docker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Services.Interfaces
{
    public interface IArticleService
    {
        List<Article> Get();
        List<Article> GetByStudentId(int studentId);
        Article Get(int id);
        Article Add(Article a);
        Article Update(Article a);
        bool Delete(int id);

        double PHDArticleRang(List<Article> articles);
        (int ConferenceCount, int JournalCount) CountArticlesByType(List<Article> articles);


    }
}
