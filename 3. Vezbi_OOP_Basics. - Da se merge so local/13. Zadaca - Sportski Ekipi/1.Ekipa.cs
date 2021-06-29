using System;
using System.Collections.Generic;

public class Ekipa
{

    public string Ime { get; set; }
    public int Pobedi { get; set; }
    public int Porazi { get; set; }

    public List<Ekipa> Ekipi { get; set; }


    public Ekipa()
    {

    }


    public Ekipa(string inputime, int inputpobedi, int inputporazi)
    {

        Ime = inputime;
        Pobedi = inputpobedi;
        Porazi = inputporazi;


    }


    public virtual void Pecati()
    {
        Console.WriteLine($"Ime: {Ime} , Pobedi: {Pobedi}, Porazi: {Porazi} ");
    }

}
