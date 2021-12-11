using System;
using System.Collections.Generic;

public class Lekar
{
    public string Ime { get; set; }

    public string Prezime { get; set; }

    public int Faksimil { get; set; }

    public decimal PocetnaPlata { get; set; }

    public Lekar(string ime, string prezime, int faksimil, decimal pocetnaplata)
    {
        Faksimil = faksimil;
        Ime = ime;
        Prezime = prezime;
        PocetnaPlata = pocetnaplata;
    }

    public virtual void Pecati()
    {
        Console.WriteLine($"{Faksimil}: {Ime} {Prezime}");
    }

    public virtual decimal Plata()
    {
        return PocetnaPlata;
    }
}