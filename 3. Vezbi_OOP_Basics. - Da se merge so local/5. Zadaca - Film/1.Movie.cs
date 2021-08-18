using System;
using System.Collections.Generic;

public class Movie
{
    private string _Ime { get; set; }

    private string _Reziser { get; set; }

    private string _Zanr { get; set; }

    private int _Godina { get; set; }


    public string GetIme() { return _Ime; }

    public string GetReziser() { return _Reziser; }

    public string GetZanr() { return _Zanr; }

    public int GetGodina() { return _Godina; }

    public Movie()
    {

    }

    public Movie(string ime, string reziser, string zanr, int godina)
    {
        _Ime = ime;
        _Reziser = reziser;
        _Zanr = zanr;
        _Godina = godina;
    }

    public void Print()
    {
        Console.WriteLine($"Ime:{GetIme()}\n" +
            $"Reziser:{GetReziser()}\n" +
            $"Zanr:{GetZanr()}\n" +
            $"Godina:{GetGodina()}");
        Console.WriteLine("\n");
    }
}