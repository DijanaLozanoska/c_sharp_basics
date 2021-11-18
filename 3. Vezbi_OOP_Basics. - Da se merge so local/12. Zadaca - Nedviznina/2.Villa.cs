using System;
using System.Collections.Generic;

public class Vila : Nedviznina
{
    public float DanokNaLuksuz { get; set; }

    public Vila(string inputadresa, string inputkvadratura, string inputcenapokvadrat, string inputdanoknaluksuz)
       : base(inputadresa, inputkvadratura, inputcenapokvadrat)
    {
        DanokNaLuksuz = float.Parse(inputdanoknaluksuz);
    }


    public override void Pecati()
    {
        base.Pecati();
    }


    public override void DanokNaImot()
    {
        float danokNaLuksuz = (0.05f + DanokNaLuksuz / 100) * (getKvadratura() * getCenaPoKvadrat());
        Console.WriteLine($"Danok na imot za {Adresa} e: {danokNaLuksuz}");
    }


}
