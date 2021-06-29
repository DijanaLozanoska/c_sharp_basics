using System;
using System.Collections.Generic;

public class Vila : Nedviznina
{
    public float danokZaVtorImot { get; set; }

    public Vila(string inputadresa, string inputkvadratura, string inputcenapokvadrat, string imputdanokzavtorimot)
       : base(inputadresa, inputkvadratura, inputcenapokvadrat)
    {
        Adresa = inputadresa;

    }

    public override void DanokNaImot()
    {

        var cena = Kvadratura * CenaPoKvadrat;
        float davackazavtorimot = (0.05f + danokZaVtorImot / 100) * cena;
        Console.WriteLine($"Danok na imot za {Adresa} e: {davackazavtorimot}");

    }
}
