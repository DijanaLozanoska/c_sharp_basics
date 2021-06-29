using System;


public class Masa
{

    public int DolzinaM { get; set; }
    public int SirinaM { get; set; }


    public Masa()
    {

    }

    public Masa(int dolzinam, int sirinam)
    {
        DolzinaM = dolzinam;
        SirinaM = sirinam;
    }


    public void Pecati()
    {

        Console.WriteLine($"Masa: {DolzinaM} {SirinaM}");

    }

}