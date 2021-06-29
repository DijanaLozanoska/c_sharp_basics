using System;

public class Employee
{

    public string Ime { get; set; }

    public int GodiniNaVraboten { get; set; }

    public int StazNaVraboten { get; set; }

    public double Plata { get; set; }

    public double Bonus { get; set; }


    public Employee(string name, int godini, int staz)
    {

        Ime = name;
        GodiniNaVraboten = godini;
        StazNaVraboten = staz;

    }

    public virtual double GetPlata()
    {
        return Plata;
    }

    public virtual double GetBonus()
    {
        return Bonus;
    }


    public bool DaliSeIstiS(Employee emp)  //not static
    {
        if (GodiniNaVraboten == emp.GodiniNaVraboten && Bonus == emp.Bonus)
        {
            return true;
        }
        return false;
    }

    public static bool DaliSeIstiS(Employee emp1, Employee emp2)  // static
    {
        if (emp1.GodiniNaVraboten == emp2.GodiniNaVraboten && emp1.Bonus == emp2.Bonus)
        {
            return true;
        }
        return false;
    }

}

