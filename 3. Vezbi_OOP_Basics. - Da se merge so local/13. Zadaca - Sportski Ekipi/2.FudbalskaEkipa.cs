using System;
using System.Collections.Generic;


public class FudbalskaEkipa : Ekipa
{

    public int CrveniKartoni { get; set; }

    public int ZoltiKartoni { get; set; }

    public int NereseniNatprevari { get; set; }

    public FudbalskaEkipa()
    {


    }


    public FudbalskaEkipa(string inputime, int inputpobedi, int inputporazi, int nereseni, List<Ekipa> fudbalskaekipa)
        : base(inputime, inputpobedi, inputporazi)
    {
        NereseniNatprevari = nereseni;
        Ekipi = fudbalskaekipa;
    }

    public int Poeni()
    {
        return Pobedi * 3;
    }

    public override void Pecati()
    {
        base.Pecati();
        Console.WriteLine($"Nereseni {NereseniNatprevari} Pobedi {Poeni()}");
    }
}

