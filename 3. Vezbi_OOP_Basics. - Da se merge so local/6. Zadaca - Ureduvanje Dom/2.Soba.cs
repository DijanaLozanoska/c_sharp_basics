using System;

public class Soba
{

    public Masa Masa { get; set; }
    public int DolzinaS { get; set; }
    public int SirinaS { get; set; }


    public Soba()
    {

    }


    public Soba(Masa masa, int dolzinas, int sirinas)
    {

        Masa = masa;
        DolzinaS = dolzinas;
        SirinaS = sirinas;

    }


    public void Pecati()
    {

        Masa.Pecati();
        Console.WriteLine($"Soba: {DolzinaS} {SirinaS}");

    }


}