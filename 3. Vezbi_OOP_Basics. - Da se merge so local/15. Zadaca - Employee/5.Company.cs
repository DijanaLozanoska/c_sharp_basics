using System;
using System.Collections.Generic;

public class Company
{

    public string Ime { get; set; }

    public int BrojNaVraboteni { get; set; }

    public List<Employee> ListaVraboteni = new List<Employee>();

    public double VkupnaPlata { get; set; }

    public double VkupnaPlataVraboten { get; set; }

    public double FiltriranaPlata { get; set; }



    public Company(string ime)
    {
        Ime = ime;
    }

    public double vkupnaPlata()
    {
        foreach (var vraboten in ListaVraboteni)
        {
            VkupnaPlata += vraboten.Plata;
        }

        return VkupnaPlata;
    }

    public static double filtriranaPlata(List<Employee> emp, Employee e)
    {

        for (int i = 0; i < emp.Count; i++)
        {
            if (emp[i].GetPlata() == e.Plata)
            {
                return emp[i].GetPlata();
            }
        }

        return e.GetPlata();
    }

    public void Lista_Vraboteni()
    {
        var freelance_employee = 0;
        var salary_employee = 0;
        var hourly_employee = 0;

        foreach (var vraboten in ListaVraboteni)
        {

            if (vraboten is FreelancerEmployee)
            {
                freelance_employee++;
            }
            if (vraboten is SalaryEmployee)
            {
                salary_employee++;
            }
            if (vraboten is HourlyEmployee)
            {
                hourly_employee++;
            }

        }

        Console.WriteLine($"Freelance employees: {freelance_employee}");
        Console.WriteLine($"Salary employees: {salary_employee}");
        Console.WriteLine($"Hourly employees: {hourly_employee}");
    }


}

