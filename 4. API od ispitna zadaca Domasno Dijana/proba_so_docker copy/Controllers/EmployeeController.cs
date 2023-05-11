using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;

namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeService.Get();
        }

        [HttpGet]
        [Route("{Id}")]
        public Employee Get(int id)
        {
            return _employeeService.Get(id);
        }


        [HttpPost]
        [Route("create")]
        public Employee Create(Employee emp)
        {
            return _employeeService.Create(emp);
        }

        [HttpPatch]
        [Route("update/{id}")]
        public Employee Update(Employee emp)
        {
            return _employeeService.Update(emp);
        }

        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            return _employeeService.Delete(id);
        }


        //[HttpGet]
        //[Route("getname")]
        //public string GetName1()
        //{
        //    var lista = _employeeService.Get();

        //    return _employeeService.GetName(lista);
        //}


        //OVA e OK

        //[HttpGet] // select faculty order by student name ASC 
        //[Route("order/{facultyId}")]
        //public FacultyOrderByResponse OrderID(int facultyId)
        //{
        //    List<Faculty> lista = _facultiesService.Get();
        //    Faculty facu = _facultiesService.Get(facultyId);

        //    FacultyOrderByRequest request_1 = new FacultyOrderByRequest() { Name = facu.Name };
        //    FacultyOrderByResponse response_1 = _facultiesService.OrderByFacultyName(lista, request_1);
        //    return response_1;
        //}


        //[HttpGet] // select faculty order by student name ASC 
        //[Route("order/{facultyId}")]
        //public FacultyOrderByResponse OrderbyStudent(int facultyId)
        //{
        //    List<Faculty> lista = _facultiesService.Get();
        //    Faculty facu = _facultiesService.Get(facultyId);

        //    FacultyOrderByRequest request_1 = new FacultyOrderByRequest() { Name = facu.Name };
        //    FacultyOrderByResponse response_1 = _facultiesService.OrderByFacultyName(lista, request_1);
        //    return response_1;
        //}


        //public 


        /*
        [HttpGet] // od predavanje 
        [Route("grades/{id}")]
        public List<GradesModelResponse> GetGrades(int id)
        {
            return _studentService.GetGrades(id);
        }
        */


    }
}
