using System;
using System.Collections.Generic;

public class Ekipa
{

    public string Ime { get; set; }
    public int Pobedi { get; set; }
    public int Porazi { get; set; }

    public Ekipa()
    {

    }


    public Ekipa(string inputime, int inputpobedi, int inputporazi)
    {
        Ime = inputime;
        Pobedi = inputpobedi;
        Porazi = inputporazi;
    }

    public virtual int Poeni()
    {
        return Pobedi;
    }

    public virtual void Pecati()
    {
        Console.WriteLine($" Ime: {Ime},\n Pobedi: {Pobedi},\n Porazi: {Porazi}");
    }

}
