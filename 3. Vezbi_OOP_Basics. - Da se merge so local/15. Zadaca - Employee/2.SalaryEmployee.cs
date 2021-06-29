using System;
using System.Collections.Generic;

public class SalaryEmployee : Employee
{

    public double OsnovnaPlata { get; set; }


    public SalaryEmployee(int osnovnaplata, string ime, int godini, int staz)
        : base(ime, godini, staz)
    {
        OsnovnaPlata = osnovnaplata;
        GetBonus();

    }


    public override double GetPlata()
    {

        var plata = OsnovnaPlata + Bonus;
        return plata;

    }


    public override double GetBonus()
    {

        var bonus = OsnovnaPlata * (GodiniNaVraboten / 100);
        return bonus;

    }

    public void Pecati()
    {

    }

}


