using proba_so_docker.Entities;
using proba_so_docker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> Get();
        Student Get(int id);
        Student Add(Student s);
        Student Update(Student s);
        bool Delete(int id);

        double Rang(int studentId);
        List<Student> GetByFacultyId(int facultyId);
        Article AddArticle(Student s, Article a);
        Article AddArticle(int studentId, int startYear, Article a);
        CountSimpleModelResponse SelectMany(CountSimpleModelRequest request);


        StudentPrintModelResponse StudentPrintSoModel(Student s);
        SelectSubjectsByFacultyResponse GroupBy(List<Student> students, List<Faculty> faculties);
        string StudentPrint(Student s);
        
    }
}
