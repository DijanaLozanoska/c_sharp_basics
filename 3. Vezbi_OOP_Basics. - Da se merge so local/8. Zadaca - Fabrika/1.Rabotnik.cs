using System;
using System.Collections.Generic;

public class Rabotnik
{
    public string Ime { get; set; }

    public string Prezime { get; set; }

    private double Plata { get; set; } 


    public Rabotnik()
    {


    }


    public Rabotnik(string ime, string prezime, double plata)
    {
        Ime = ime;
        Prezime = prezime;
        Plata = plata;
    }


    public double GetPlata
    {
        get { return Plata; }
        set { Plata = value; }
    }


    public void Pecati()
    {
        Console.WriteLine($"Ime: {Ime} , Prezime: {Prezime}, Plata: {GetPlata} ");
    }
}

