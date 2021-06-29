using System;
using System.Collections.Generic;

public class FreelancerEmployee : Employee
{
    public int BrojNaProekti { get; set; }

    public List<double> SumaZaProekti { get; set; }

    public double Vkupnasuma { get; set; }


    public FreelancerEmployee(int brojnaproekti, List<double> sumazaproekti, double vkupnaplata, string ime, int godini, int staz)
        : base(ime, godini, staz)
    {
        BrojNaProekti = brojnaproekti;

        SumaZaProekti = new List<double>();
    }


    public override double GetPlata()
    {
        Plata = (Vkupnasuma + Bonus);
        return Plata;

    }


    public override double GetBonus()
    {

        if (BrojNaProekti > 5)
        {
            Bonus = (BrojNaProekti - 5) * 1000;


        }
        return Bonus;

    }

}

