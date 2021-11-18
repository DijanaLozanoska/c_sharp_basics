using System;
using System.Collections.Generic;


public class FudbalskaEkipa : Ekipa
{

    public int CrveniKartoni { get; set; }

    public int ZoltiKartoni { get; set; }

    public int NereseniNatprevari { get; set; }

    public Ekipa Ekipa { get; set; }



    public FudbalskaEkipa()
    {


    }

    public FudbalskaEkipa(string inputime, int inputpobedi, int inputporazi, int nereseni)
        :base(inputime, inputpobedi, inputporazi)
    {
        NereseniNatprevari = nereseni;
    }

    public override int Poeni()
    {
        return Ekipa.Poeni() * 3 + NereseniNatprevari;
    }

    public override void Pecati()
    {
        Ekipa.Pecati();
        Console.WriteLine($" Nereseni: {NereseniNatprevari},\n Poeni: {Poeni()}");
    }
}

