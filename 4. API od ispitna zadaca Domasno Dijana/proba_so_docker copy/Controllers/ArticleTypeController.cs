using System.Collections.Generic;
using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesTypesController : ControllerBase
    {
        private readonly IArticleTypeService _articleTypeService;

        public ArticlesTypesController(IArticleTypeService articleTypeService)
        {
            _articleTypeService = articleTypeService;

        }

        [HttpGet]
        public List<ArticleType> Get()
        {
            return _articleTypeService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public ArticleType Get(int id)
        {
            return _articleTypeService.Get(id);
        }

        [HttpGet]
        [Route("{value}")]
        public ArticleType Get(string value)
        {
            return _articleTypeService.Get(value);
        }

        [HttpPatch]
        [Route("update")]
        public ArticleType Update(ArticleType faculty)
        {
            return _articleTypeService.Update(faculty);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _articleTypeService.Delete(id);
        }
    }
}