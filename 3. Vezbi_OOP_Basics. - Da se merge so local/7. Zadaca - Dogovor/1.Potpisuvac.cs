using System;
using System.Collections.Generic;

public class Potpisuvac
{
    public string Ime { get; set; }

    public string Prezime { get; set; }

    public double EMBG { get; set; }


    public Potpisuvac()
    {

    }

    public Potpisuvac(string input_ime, string input_prezime, double input_embg)
    {
        Ime = input_ime;
        Prezime = input_prezime;
        EMBG = input_embg;
    }
}