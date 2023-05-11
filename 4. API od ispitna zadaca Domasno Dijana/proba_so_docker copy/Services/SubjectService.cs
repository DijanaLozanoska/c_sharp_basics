using proba_so_docker.Data;
using proba_so_docker.Entities;
using proba_so_docker.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using proba_so_docker.Models;

namespace proba_so_docker.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IApplicationDbContext db;
        private readonly IStudentService _studentService;

        public SubjectService(IApplicationDbContext db, IStudentService studentService)
        {
            this.db = db;
            _studentService = studentService;
        }


        public List<Subject> Get()
        {
            return db.Subject.ToList();
        }

        public Subject Get(int id)
        {
            return db.Subject.FirstOrDefault(f => f.Id == id);
        }


        public Subject Add(Subject s)
        {
            var subject = db.Subject.Add(s);
            db.SaveChanges();
            return subject.Entity;
        }


        public Subject Update(Subject s)
        {
            var updatedSubject = db.Subject.Update(s);
            db.SaveChanges();
            return updatedSubject.Entity;
        }


        public bool Delete(int id)
        {
            var subject = db.Subject.FirstOrDefault(f => f.Id == id);
            db.Subject.Remove(subject);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }


        public List<Subject> AddRange(int facultyId, Subject s)
        {
            var faculty = _studentService.GetByFacultyId(facultyId);
            var subject = Add(s);

            List<Subject> lista = new List<Subject>();
            foreach (var item in lista)
            {
                lista.Add(subject);
            }
            db.SaveChanges();
            return lista.ToList();  // od predavanje 

        }

        public List<Subject> AddRange(int facultyId)
        {
            throw new System.NotImplementedException(); 
        }
    }
}
