using proba_so_docker.Entities;
using proba_so_docker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Services.Interfaces
{
    public interface IStudentSubjectService
    {
        List<StudentSubject> Get();
        StudentSubject Get(int id);
        StudentSubject Add(StudentSubject ss);
        StudentSubject Update(StudentSubject ss);
        bool Delete(int id);

        double Rang(List<StudentSubject> studentSubject);
        StudentRangResponse RangStudentSubject(List<StudentSubject> studentSubject, StudentRangRequest srreq);
        MinMaxStudentSubjectResponse GetMaxGrade(List<StudentSubject> studentSubject, MinMaxStudentSubjectRequest mmssreq);
        MinMaxStudentSubjectResponse GetMinGrade(List<StudentSubject> studentSubject, MinMaxStudentSubjectRequest mmssreq);
    }
}
