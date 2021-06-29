using System;
using System.Collections.Generic;

public class Nedviznina
{

    public string Adresa { get; set; }
    public int Kvadratura { get; set; }
    public int CenaPoKvadrat { get; set; }


    public Nedviznina(string inputadresa, string inputkvadratura, string inputcenapokvadrat)
    {

        Adresa = inputadresa;
        Kvadratura = int.Parse(inputkvadratura);
        CenaPoKvadrat = int.Parse(inputcenapokvadrat);

    }


    public virtual void Pecati()
    {

        Console.WriteLine($"Adresata e: {Adresa}, Kvadratura: {Kvadratura}, Cena po Kvadrat: {CenaPoKvadrat}");

    }

    public virtual void DanokNaImot()
    {
        var cena = Kvadratura * CenaPoKvadrat;
        float danok = 0.05f * cena;
        Console.WriteLine($"Danok na imot za {Adresa} e: {danok}");
        Console.WriteLine();

    }

}