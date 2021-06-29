using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IFacultyService _facultiesService;

        public StudentsController(IStudentService studentService, IFacultyService facultiesService)
        {
            _studentService = studentService;
            _facultiesService = facultiesService;
        }


        [HttpGet]
        public List<Student> Get()
        {
            return _studentService.Get();
        }


        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            return _studentService.Get(id);
        }


        [HttpGet]
        [Route("Faculty/{id}")]
        public List<Student> GetStudentsByFacultyId(int id)
        {
            return _studentService.GetByFacultyId(id);
        }


        [HttpPost]
        [Route("create")]
        public Student Create(Student model)
        {
            return _studentService.Add(model);
        }


        [HttpPatch]
        [Route("update")]
        public Student Update(Student student)
        {
            return _studentService.Update(student);
        }


        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            return _studentService.Delete(id);
        }


        [HttpGet]
        [Route("print/{studentId}")]
        public StudentPrintModelResponse Print(int studentId)
        {
            Student stud = _studentService.Get(studentId);
            //StudentPrintModelResponse response_s = new StudentPrintModelResponse();
            var response = _studentService.StudentPrintSoModel(stud); 
            return response;
        }


        [HttpGet]
        [Route("{id}/rang")]
        public double Rang(int id)
        {
            return _studentService.Rang(id);
        }


        [HttpGet]
        [Route("group_by")]
        public SelectSubjectsByFacultyResponse GroupBy1()
        {

            List<Student> lista_studenti = _studentService.Get();
            List<Faculty> lista_fakulteti = _facultiesService.Get();

            SelectSubjectsByFacultyResponse response_1 = _studentService.GroupBy(lista_studenti,lista_fakulteti);
            return response_1;
        }


        [HttpGet]
        [Route("count")]
        public CountSimpleModelResponse SelectManyQuery(int id_student)
        {
            Student student_request = _studentService.Get(id_student);

            CountSimpleModelRequest request = new CountSimpleModelRequest() { Name = student_request.Name };
            CountSimpleModelResponse response = _studentService.SelectMany(request);  //, id_student);

            return response;
        }


        /*
       [HttpGet] // ova od Ilija mi e prepisano 
       [Route("grades/{id}")]
       public List<GradesModelResponse> GetGrades(int id)
       {
           return _studentService.GetGrades(id);
       }
       */


        /*
        [HttpGet]
        [Route("count/{studentId}")]
        public ArticleCountResponse ArticleCounttSoModel(int studentId)
        {
        
            Student stud1 = _studentService.Get(studentId);

            StudentRangRequest request_2 = new StudentRangRequest() { Name = stud1.Name };
            ArticleCountResponse response = _studentService.ArticleCounttSoModel(stud1, request_2);

            return response;
        }
        */


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

        //var select_by_fax_id = db.Faculty.Select(x => x.Name).ToList();

        //    FacultyOrderByRequest request_1 = new FacultyOrderByRequest() { Name = facu.Name };
        //    FacultyOrderByResponse response_1 = _facultiesService.OrderByFacultyName(lista, request_1);
        //    return response_1;
        //}



    }
}
