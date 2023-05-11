using proba_so_docker.Entities;
using proba_so_docker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proba_so_docker.Models;

namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultiesService;

        public FacultiesController(IFacultyService facultiesService)
        {
            _facultiesService = facultiesService;
        }


        [HttpGet]
        public List<Faculty> Get()
        {
            return _facultiesService.Get();
        }


        [HttpGet]
        [Route("{id}")]
        public Faculty Get(int id)
        {
            return _facultiesService.Get(id);
        }


        [HttpPost]
        [Route("create")]
        public Faculty Create(Faculty model)
        {
            return _facultiesService.Add(model);
        }


        [HttpPatch]
        [Route("update")]
        public Faculty Update(Faculty faculty)
        {
            return _facultiesService.Update(faculty);
        }


        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            return _facultiesService.Delete(id);
        }


        [HttpGet] // order by faculty id ASC 
        [Route("order_asc")]
        public FacultyOrderByResponse OrderNameAsc()
        {
            List<Faculty> lista = _facultiesService.Get();
            FacultyOrderByResponse response_1 = _facultiesService.OrderByFacultyNameAsc(lista);
            return response_1;
        }


        [HttpGet] // order by faculty id DESC 
        [Route("order_desc")]
        public FacultyOrderByResponse OrderNameDesc()
        {
            List<Faculty> lista = _facultiesService.Get();
            FacultyOrderByResponse response_2 = _facultiesService.OrderByFacultyNameDesc(lista);
            return response_2;
        }
    }
}
