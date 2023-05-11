using proba_so_docker.Data;
using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proba_so_docker.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext db;
        private readonly IStudentSubjectService _studentSubjectService;
        private readonly IArticleService _articleService;
        


        public StudentService(IApplicationDbContext db, IStudentSubjectService studentSubjectService, IArticleService articleService)
        {
            this.db = db;
            _studentSubjectService = studentSubjectService;
            _articleService = articleService;
           
        }


        public List<Student> Get()
        {
            return db.Student.ToList();
        }


        public Student Get(int id)
        {
            return db.Student.FirstOrDefault(x => x.Id == id);
        }


        public Student Add(Student s)
        {
            var student = db.Student.Add(s);
            db.SaveChanges();
            return student.Entity;
        }


        public Student Update(Student s)
        {
            var updatedStudent = db.Student.Update(s);
            db.SaveChanges();
            return updatedStudent.Entity;
        }


        public bool Delete(int id)
        {
            var student = db.Student.FirstOrDefault(x => x.Id == id);
            db.Student.Remove(student);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }


        public List<Student> GetByFacultyId(int facultyId)
        {
            var students = db.Student.Where(x => x.FacultyId == facultyId).ToList();
            return students;
        }

        // od predavanje 
        public (int ConferenceCount, int JournalCount) CountArticlesTypeByStudentId(int studentId)
        {
            var articles = _articleService.GetByStudentId(studentId);
            return _articleService.CountArticlesByType(articles);
        }

        // od predavanje 
        public double Rang(int studentId)
        {
            var student = db.Student.Where(x => x.Id == studentId).FirstOrDefault();
            return Rang(student);
        }

        // od predavanje 
        public double Rang(Student student)
        {
            var isPhd = student.IsPHD;
            var studentSubject = db.StudentSubjects.Where(ss => ss.StudentId == student.Id).ToList();
            var rang = _studentSubjectService.Rang(studentSubject);

            if (isPhd)
            {
                var articles = db.Article.Include(x => x.Type).Where(article => article.StudentId == student.Id).ToList();
                return rang + _articleService.PHDArticleRang(articles);
            }

            return rang;
        }

        public Article AddArticle(Student s, Article a)
        {
            var addedArticle = AddArticle(s.Id, s.StartYear, a);
            return addedArticle;
        }

        public Article AddArticle(int studentId, int startYear, Article a)
        {
            if (a.PublishYear < startYear)
                throw new Exception("Article publish year is older then the student start year.");

            a.StudentId = studentId;
            var addedArticle = _articleService.Add(a);
            return addedArticle;
        }

        public int SelectMany(int facultyId)
        {
     
            List<Student> lista_students = new List<Student> ();

            ICollection<Article> lista_articles = (ICollection<Article>)lista_students.Select(x => x.Articles);

            var results = lista_students.Select(user => user.Id == facultyId)
                  .GroupBy(StartYear => StartYear)
                  .Select(gr => new { StartYear = gr.Key, Total = gr.Count() });

          
            var count = db.Student
            .Where(o => o.FacultyId == facultyId)
            .SelectMany(o => o.Articles)
            .Count();

            return count;
        }

        public CountSimpleModelResponse SelectMany(CountSimpleModelRequest request) //int id
        {

            var count = db.Student
             //.Where(o => o.FacultyId == id)
             .SelectMany(o => o.Articles)
             .Count();

            var count_count = count;

            CountSimpleModelResponse response = new CountSimpleModelResponse { Name = request.Name, Count = count_count };
            return response;
        }


        public string StudentPrint(Student s)
        {
            return $"StudentId: {s.Id}, Student Name: {s.Name}, {s.StartYear} {Rang(s)}";
        }


        public StudentPrintModelResponse StudentPrintSoModel(Student s)
        {
            StudentPrintModelResponse response = new StudentPrintModelResponse() { StudentId = s.Id, StudentName = s.Name, StudentStartYear = s.StartYear, StudentRang = Rang(s) };
            return response;
        }


        public SelectSubjectsByFacultyResponse GroupBy(List<Student> students, List<Faculty> faculties)
        {
            var newList = db.Student
            .GroupBy(u => new { u.Name, u.FacultyId })
            .Select(y => new Student()
            {
                Name = y.Key.Name,
                FacultyId = y.Sum(t => t.FacultyId)
            }
            ).ToList();

            var newList1 = db.Faculty
            .GroupBy(u => new { u.Name, u.Id })
            .Select(y => new Faculty()
            {
                Name = y.Key.Name,
                Id = y.Sum(t => t.Id)
            }
            ).ToList();

            SelectSubjectsByFacultyResponse ssbfr = new SelectSubjectsByFacultyResponse() // ova bez request si e OK
            { Faculties = newList1, Students = newList };
            return ssbfr;
        }


        public List<GradesModelResponse> GetGrades(int studentId)
        {
            var studentP = db.Student.FirstOrDefault(x => x.Id == studentId); // go dava studentot so broj s
            var studentSubjects = db.StudentSubjects.Where(x => x.StudentId == studentId).ToList();
            var lista = new List<GradesModelResponse>();

            foreach (var ss in studentSubjects) // moze da se zeme deka e ToList 
            {
                var subject = db.Subject.FirstOrDefault(x => x.Id == ss.SubjectId);
                lista.Add(new GradesModelResponse()
                {
                    Name = subject.Name,
                    Grade = ss.Grade
                });
            }

            var student = db.Student.Include(s => s.StudentSubjects).ThenInclude(s => s.Subject).FirstOrDefault(x => x.Id == studentId);
            var ssubjects = student.StudentSubjects.ToList();
            var grades = new List<GradesModelResponse>();

            foreach (var ss in ssubjects)
            {
                grades.Add(new() { Name = ss.Subject.Name, Grade = ss.Grade });
            }

            return grades;
        }
        /*so select 
         var student = db.Student.Include(s => s.StudentSubjects).ThenInclude(s => s.Subject).FirstOrDefault(x => x.Id == studentId);
         var ssubjects = student.StudentSubjects.ToList()
         .Select(x=>GradesModelResponse(){Name => x.Subject.Name, Grade =x.Grade }).ToList();

         return ssubjects

    }
     

        public string CountPoFacultyId(int facultyId)
        {
        var modules = db.Student.Include(f => f.StudentSubjects)
             .Where(e => e.FacultyId == facultyId)
             .Select(a => a.Faculty.Name)
             .ToList();

        var q = from x in modules
                group x by x into g
                let count = g.Count()
                orderby count descending
                select (g.Key + " (" + count + ")").ToString();

        return String.Join(", ", q);
        }

            public string CountPoArticles(Student s)
            {

             var queryLastNames =
             from Articles in db.Student
             group Articles by Articles.Name into newGroup
             orderby newGroup.Key
             select newGroup;

            return String.Join(", ", queryLastNames);

            foreach (var nameGroup in queryLastNames)
        {
            Console.WriteLine($"Key: {nameGroup.Key}");
            foreach (var student in nameGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }

    }   */


    } 
}
