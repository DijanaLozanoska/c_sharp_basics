using proba_so_docker.Entities;
using proba_so_docker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using proba_so_docker.Models;

namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;

        public SubjectsController(ISubjectService subjectService, IStudentService studentService)
        {
            _subjectService = subjectService;
            _studentService = studentService;
        }


        [HttpGet]
        public List<Subject> Get()
        {
            return _subjectService.Get();
        }


        [HttpGet]
        [Route("{id}")]
        public Subject Get(int id)
        {
            return _subjectService.Get(id);
        }


        [HttpPost]
        [Route("create")]
        public Subject Create(Subject model)
        {
            return _subjectService.Add(model);
        }


        [HttpPatch]
        [Route("update")]
        public Subject Update(Subject faculty)
        {
            return _subjectService.Update(faculty);
        }


        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _subjectService.Delete(id);
        }


        //[HttpPost]
        //[Route("addrange/{id}")]
        //public List<Subject> AddRange(int id)
        //{
        //    return _subjectService.AddRange(id);

        //}
    }
}
