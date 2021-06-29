using System.Collections.Generic;
using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IArticleTypeService _articleTypeService;
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService, IArticleTypeService articleTypeService, IStudentService studentService)
        {
            _studentService = studentService;
            _articleTypeService = articleTypeService;
            _articleService = articleService;
        }


        [HttpGet]
        public List<Article> Get()
        {
            return _articleService.Get();
        }


        [HttpGet]
        [Route("{id}")]
        public Article Get(int id)
        {
            return _articleService.Get(id);
        }


        [HttpPost]
        [Route("create")]
        public Article Create(Article model)
        {
            return _articleService.Add(model);
        }


        [HttpPatch]
        [Route("update/{id}")]
        public Article Update(Article article)
        {
            return _articleService.Update(article);
        }


        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            return _articleService.Delete(id);
        }


        [HttpPost]
        [Route("{studentId}")]
        public Article AddArticle(int studentId, ArticleModelRequest avm)
        {
            var articleType = _articleTypeService.Get(avm.Type);
            var student = _studentService.Get(studentId);
            var article = new Article()
            {
                PublishYear = avm.PublishYear,
                Title = avm.Title,
                TypeId = articleType.Id,
                FacultyId = student.FacultyId,
                StudentId = studentId,
            };

            var addedArticle = _studentService.AddArticle(studentId, student.StartYear, article);
            return addedArticle;
        }
    }
}
