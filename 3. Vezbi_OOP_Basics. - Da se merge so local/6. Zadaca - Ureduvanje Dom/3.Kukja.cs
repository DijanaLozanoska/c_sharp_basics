using System;
using System.Collections.Generic;

public class Kukja
{
    public string Adresa { get; set; }

    public Soba Soba { get; set; }

    public List<Kukja> Kukji { get; set; }


    public Kukja()
    {

    }

    public Kukja(string adresa, Soba soba, List<Kukja> kukji)
    {

        Adresa = adresa;
        Soba = soba;
        Kukji = kukji;

    }

    public void Pecati()
    {

        Console.WriteLine($"Adresa: {Adresa}");
        Soba.Pecati();


    }

}
