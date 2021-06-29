using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaEmployee
    {
        public static void EmployeeVoid()
        {
            Employee emp1 = new SalaryEmployee(22000, "Daniel", 23, 10);
            Employee emp2 = new HourlyEmployee(15, 200, 24000, "Monika", 27, 5);
            Employee emp3 = new FreelancerEmployee(5, new List<double>() { 1000, 2000, 3000, 4000, 5000 }, 10000, "Dimitar", 28, 3);

            var dali = Employee.DaliSeIstiS(emp1, emp2); //static
            var dali_e_isto_so = emp1.DaliSeIstiS(emp2); // not static

            Company company = new Company("Dijana");
            company.ListaVraboteni = new List<Employee>() { emp1, emp2, emp3 };
            company.Lista_Vraboteni();

            Console.WriteLine("Done");
        }
    }
}
