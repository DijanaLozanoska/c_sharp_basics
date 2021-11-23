using System;
using System.Collections.Generic;

public class Person
{
    public string Ime { get; set; } = "not specified";

    public string Prezime { get; set; } = "not specified";

    public Person()
    {

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
