using proba_so_docker.Data;
using proba_so_docker.Entities;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proba_so_docker.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly IApplicationDbContext db;
        public StudentSubjectService(IApplicationDbContext db)
        {
            this.db = db;
        }


        public List<StudentSubject> Get()
        {
            return db.StudentSubjects.ToList();
        }

        public StudentSubject Get(int id)
        {
            return db.StudentSubjects.FirstOrDefault(f => f.Id == id);
        }


        public StudentSubject Add(StudentSubject ss)
        {
            if (ss.Grade > 10)

            
            throw new Exception("The value is greater then 10.");
            var studentSubject = db.StudentSubjects.Add(ss);
            db.SaveChanges();
            return studentSubject.Entity;
        }


        public StudentSubject Update(StudentSubject ss)
        {
            var updatedStudentSubject = db.StudentSubjects.Update(ss);
            db.SaveChanges();
            return updatedStudentSubject.Entity;
        }


        public bool Delete(int id)
        {
            var studentSubject = db.StudentSubjects.FirstOrDefault(f => f.Id == id);
            db.StudentSubjects.Remove(studentSubject);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }


        public double Rang(List<StudentSubject> studentSubject)
        {
            var rang = 0.0;

            foreach (var subject in studentSubject)
            {
                rang += subject.Grade;
            }

            return rang / studentSubject.Count;
        }


        public StudentRangResponse RangStudentSubject(List<StudentSubject> studentSubject, StudentRangRequest srreq)
        {
            var rang = 0.0;

            foreach (var subject in studentSubject)
            {
                rang += subject.Grade;
            }
             var rang_rang =  rang / studentSubject.Count;

            StudentRangResponse srr = new StudentRangResponse() { Name = srreq.Name, Rang = rang_rang };

            return srr;
        }


        public MinMaxStudentSubjectResponse GetMaxGrade(List<StudentSubject> studentSubject, MinMaxStudentSubjectRequest mmssreq)
        {
            var min = db.StudentSubjects.Max(x => x.Grade);

            MinMaxStudentSubjectResponse mmssr = new MinMaxStudentSubjectResponse() { Name = mmssreq.Name, Subject = mmssreq.Subject, MinimumOrMaximum = min };
            return mmssr;
        }


        public MinMaxStudentSubjectResponse  GetMinGrade(List<StudentSubject> studentSubject, MinMaxStudentSubjectRequest mmssreq)
        {
            var min = db.StudentSubjects.Min(x => x.Grade);

            MinMaxStudentSubjectResponse mmssr = new MinMaxStudentSubjectResponse() { Name = mmssreq.Name, Subject = mmssreq.Subject, MinimumOrMaximum = min };
            return mmssr;
        }
    }
}
