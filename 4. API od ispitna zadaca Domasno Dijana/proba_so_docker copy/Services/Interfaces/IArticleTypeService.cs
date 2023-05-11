using proba_so_docker.Entities;
using proba_so_docker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Services.Interfaces
{
    public interface IArticleTypeService
    {
        List<ArticleType> Get();
        ArticleType Get(int id);
        ArticleType Get(string value);
        ArticleType Add(ArticleType at);
        ArticleType Update(ArticleType at);
        bool Delete(int id);
       
    }
}
