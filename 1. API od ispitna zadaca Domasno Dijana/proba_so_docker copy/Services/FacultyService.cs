using proba_so_docker.Data;
using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace proba_so_docker.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IApplicationDbContext db;
        public FacultyService(IApplicationDbContext db)
        {
            this.db = db;
        }


        public List<Faculty> Get()
        {
            return db.Faculty.ToList();  ////-tuka vrakjame samo Id i Name od entitetot Fakultet. Ostanatite propertinja se null!
            //return db.Faculty.Include(f => f.Students).ToList();  ////-tuka vrakjame Fakulteti zaedno so lista od studenti!
            //return db.Faculty.Include(f => f.Students).ThenInclude(s => s.Articles).ToList();
        }


        public Faculty Get(int id)
        {
            return db.Faculty.FirstOrDefault(f => f.Id == id);
        }


        public Faculty Add(Faculty faculty)
        {
            var f = db.Faculty.Add(faculty);
            db.SaveChanges();
            return f.Entity;
        }


        public Faculty Update(Faculty faculty)
        {
            var updatedFaculty = db.Faculty.Update(faculty);
            db.SaveChanges();
            return updatedFaculty.Entity;
        }


        public bool Delete(int id)
        {
            var faculty = db.Faculty.FirstOrDefault(f => f.Id == id);
            db.Faculty.Remove(faculty);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }


        //newFaculty - e objektot so osvezeni informacii na primer PMF sega e PRAVEN fakultet
        public Faculty SafeUpdate(int id, Faculty newFaculty)
        {
            var oldFaculty = db.Faculty.FirstOrDefault(f => f.Id == id); // bil PMF
            oldFaculty.Name = newFaculty.Name; // go menuvam imeto PMF so Praven
            var faculty = db.Faculty.Update(oldFaculty); // Ja updejtiram bazata
            // vrakja int, kolku promeni bile izvrseni. 
            //Vo ovoj slucaj toj broj treba da bide 1
            var count = db.SaveChanges();
            return faculty.Entity;
        }


        public StudentRangResponse RangStudentSubject(List<StudentSubject> studentSubject, StudentRangRequest srreq)
        {
            var rang = 0.0;

            foreach (var subject in studentSubject)
            {
                rang += subject.Grade;
            }
            var rang_rang = rang / studentSubject.Count;

            StudentRangResponse srr = new StudentRangResponse() { Name = srreq.Name, Rang = rang_rang };

            return srr;
        }


        public FacultyOrderByResponse OrderByFacultyNameAsc(List<Faculty> faculties)
        {

            var order = db.Faculty.OrderBy(x => x.Name).ToList();
            FacultyOrderByResponse fobr = new FacultyOrderByResponse() { Order = order };
            return fobr;

        }


        public FacultyOrderByResponse OrderByFacultyNameDesc(List<Faculty> faculties)
        {

            var order = db.Faculty.OrderByDescending(x => x.Name).ToList();
            FacultyOrderByResponse fobr = new FacultyOrderByResponse() { Order = order };
            return fobr;

        }
    }
}
