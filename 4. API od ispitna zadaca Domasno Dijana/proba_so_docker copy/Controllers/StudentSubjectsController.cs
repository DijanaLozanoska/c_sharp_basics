using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace proba_so_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentSubjectsController : ControllerBase
    {
        private readonly IStudentSubjectService _studentSubjectService;

        private readonly IStudentService _studentService;

        private readonly ISubjectService _subjectService;

        public StudentSubjectsController(ISubjectService subjectService, IStudentService studentService, IStudentSubjectService studentSubjectService)
        {
            _studentSubjectService = studentSubjectService;
            _studentService = studentService;
            _subjectService = subjectService;
        }


        [HttpGet]
        public List<StudentSubject> Get()
        {
            return _studentSubjectService.Get();
        }


        [HttpGet]
        [Route("{id}")]
        public StudentSubject Get(int id)
        {
            return _studentSubjectService.Get(id);
        }


        [HttpPost]
        [Route("create")]
        public StudentSubject Create(StudentSubject model)
        {
            return _studentSubjectService.Add(model);
        }


        [HttpPatch]
        [Route("update")]
        public StudentSubject Update(StudentSubject ss)
        {
            return _studentSubjectService.Update(ss);
        }


        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _studentSubjectService.Delete(id);
        }


        [HttpGet]
        [Route("rang/{studentId}")]
        public StudentRangResponse Rang(int studentId)
        {
            List<StudentSubject> lista = _studentSubjectService.Get();
            Student stud = _studentService.Get(studentId); // student so studentid

            StudentRangRequest request_1 = new StudentRangRequest() { Name = stud.Name };
            StudentRangResponse response_1 = _studentSubjectService.RangStudentSubject(lista, request_1);

            return response_1;
        }


        [HttpGet] // samo rang 
        [Route("rang1/{studentId}")]
        public double SamoRang()
        {
            List<StudentSubject> lista = _studentSubjectService.Get();
            return _studentSubjectService.Rang(lista);
        }


        [HttpGet] // lista od student subjects 
        [Route("print/{studentId}")]
        public string PrintNaLista()
        {
            List<StudentSubject> lista = _studentSubjectService.Get();
            return null; //_studentSubjectService.Rang(lista);
        }


        [HttpGet]
        [Route("max/{studentId}")]
        public MinMaxStudentSubjectResponse MaxGrade(int studentId)
        {
            Student stud_name = _studentService.Get(studentId);
            Subject subj_subj = _subjectService.Get(studentId);

            List<StudentSubject> lista = _studentSubjectService.Get();

            MinMaxStudentSubjectRequest request_1 = new MinMaxStudentSubjectRequest() { Name = stud_name.Name, Subject = subj_subj.Name };
            MinMaxStudentSubjectResponse response_1 = _studentSubjectService.GetMaxGrade(lista, request_1);
            return response_1;
        }


        [HttpGet]
        [Route("min/{studentId}")]
        public MinMaxStudentSubjectResponse MinGrade(int studentId)
        { 
            Student stud_name = _studentService.Get(studentId);
            Subject subj_subj = _subjectService.Get(studentId);

            List<StudentSubject> lista = _studentSubjectService.Get();

            MinMaxStudentSubjectRequest request_1 = new MinMaxStudentSubjectRequest() { Name = stud_name.Name, Subject = subj_subj.Name };
            MinMaxStudentSubjectResponse response_1 = _studentSubjectService.GetMinGrade(lista , request_1);
            return response_1;
        }
    }
}