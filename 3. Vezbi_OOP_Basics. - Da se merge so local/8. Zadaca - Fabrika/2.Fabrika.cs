using System;
using System.Collections.Generic;

public class Fabrika
{
    public Rabotnik Rabotnik { get; set; }

    public int BrojNaVraboteni { get; set; }

    public List<Rabotnik> Vraboteni { get; set; }


    public Fabrika( )
    {

    }

    public Fabrika (List<Rabotnik> rabotnik)
    {
        Vraboteni = rabotnik;
    }


    public void PecatiVraboteni()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Site Vraboteni:");
        foreach (var vraboten in Vraboteni)
        {
            vraboten.Pecati();
        }
    }


    /* moze i so for

    public void PecatiVraboteni()
    {
        for (int i = 0; i < BrojNaVraboteni; i++)
        {
            BrojNaVraboteni[i].Pecati();
        }
    }
    */

    public void PecatiSoPlata(int plata)
    {
        Console.WriteLine("Vraboteni so plata povisoka od 30000:");
        foreach (var pogolemaplata in Vraboteni)
        {
            if (pogolemaplata.GetPlata > plata)
            {
                pogolemaplata.Pecati();
            }
        }
    }
}