using System;
using System.Collections.Generic;

public class Person
{
    public string Ime { get; set; }

    public string Prezime { get; set; }

    public Person()
    {
        Ime = "not specified";
        Prezime = "not specified";
    }

    public Person(string ime, string prezime)
    {

        Ime = ime;
        Prezime = prezime;

    }


    public void Print()
    {
        Console.WriteLine($"{Ime} {Prezime}");

    }
}
