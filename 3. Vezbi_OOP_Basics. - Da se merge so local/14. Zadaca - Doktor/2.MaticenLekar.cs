using System;
using System.Collections.Generic;

public class MaticenLekar : Lekar
{
    public int Pacienti { get; set; }

    public List<decimal> Kotizacija { get; set; }

    public MaticenLekar(string ime, string prezime, int faksimil, decimal plata, int pacienti, List<decimal> kotizacii)
        : base(ime, prezime, faksimil, plata)
    {
        Pacienti = pacienti;
        Kotizacija = kotizacii;
    }

    public override void Pecati()
    {

        base.Pecati();
        Console.WriteLine($"Osnovnata plata na gorenavedeniot lekar e : {base.Plata():c} ");
        Console.WriteLine($"Vkupnata plata so kotizacija e {Plata():c} ");

    }

    public override decimal Plata()
    {
        decimal kotizacii = 0;
        foreach (var kotizacija in Kotizacija)
        {
            kotizacii += kotizacija;
        }

        return base.Plata() + (kotizacii / Kotizacija.Count) * (30m / 100m);
    }
}

