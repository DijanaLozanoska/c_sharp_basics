using System;
using System.Collections.Generic;

public class Car
{

    public Person Sopstvenik { get; set; }

    public Datum DatumNaKupuvanje { get; set; }

    public float Cena { get; set; }


    public Car()
    {
        Sopstvenik = new Person();
        DatumNaKupuvanje = new Datum();
        Cena = 0f;

    }

    public Car(Person sopstvenik, Datum datumnakupuvanje, float cena)
    {
        Sopstvenik = sopstvenik;
        DatumNaKupuvanje = datumnakupuvanje;
        Cena = cena;

    }

    public void Print()
    {

        Sopstvenik.Print();
        DatumNaKupuvanje.Print();
        GetPrice();

    }


    public void GetPrice()
    {
        Console.WriteLine($"{Cena}");
    }
}
