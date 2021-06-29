using System;
using System.Collections.Generic;

public class HourlyEmployee : Employee
{

    public double BrojnaCasovi { get; set; }

    public double PlataPoCas { get; set; }

    public double VkupnaPlata { get; set; }


    public HourlyEmployee(double brojnacasovi, double platapocas, double vkupnaplata, string ime, int godini, int staz)
        : base(ime, godini, staz)
    {

        BrojnaCasovi = brojnacasovi;
        PlataPoCas = platapocas;
        VkupnaPlata = vkupnaplata;


    }

    public override double GetPlata()
    {
        if (BrojnaCasovi > 320)
        {
            Bonus = (50 / 100) * PlataPoCas;
            VkupnaPlata = (BrojnaCasovi * PlataPoCas) + Bonus;
        }
        else
        {
            Bonus = 0;
            VkupnaPlata = (BrojnaCasovi * PlataPoCas) + Bonus;
        }
        return Plata;

    }


    public double vkupnaPlata()
    {
        VkupnaPlata = (BrojnaCasovi * PlataPoCas) + Bonus;
        return VkupnaPlata;
    }


    public override double GetBonus()
    {
        if (BrojnaCasovi > 320)
        {
            var razlika = BrojnaCasovi - 320;
            Bonus = ((PlataPoCas * 50 / 100) + PlataPoCas) * razlika;

        }
        return Bonus;
    }

}

