using System;
using System.Collections.Generic;
using proba_so_docker.Models;

namespace proba_so_docker.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee Get(int id);
        Employee Create(Employee emp);
        Employee Update(Employee emp);
        bool Delete(int id);


        //EmployeeModel GetName(List<Employee> employees);


        //SelectSubjectsByFacultyResponse Students1(List<Student> student); ova e ok

    }
}
