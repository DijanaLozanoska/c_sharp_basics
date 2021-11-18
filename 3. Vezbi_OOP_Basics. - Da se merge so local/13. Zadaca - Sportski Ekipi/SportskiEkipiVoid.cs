using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaSportskiEkipi
    {
        public static void SportskiEkipiVoid()
        {
            //// bez readline 
            //var ekipa = new Ekipa { Ime = "Fudbaleri", Pobedi = 5, Porazi = 4 };

            //var fudbalska_ekipa = new FudbalskaEkipa { Ekipa = ekipa, NereseniNatprevari = 6, ZoltiKartoni = 7 };

            //var fudbalska_ekipa_lista = new List<FudbalskaEkipa>();
            //fudbalska_ekipa_lista.Add(fudbalska_ekipa);

            //foreach (var item in fudbalska_ekipa_lista)
            //{
            //    item.Pecati();
            //}

            var readline_lista_na_fud_ekipi = new List<FudbalskaEkipa>();
            var ime = Console.ReadLine();
            var pobedi = Console.ReadLine();
            var porazi = Console.ReadLine();
            var nereseni = Console.ReadLine();
            var zolti_kartoni = Console.ReadLine();

            Ekipa ekipa1 = new Ekipa { Ime = ime, Pobedi = int.Parse(pobedi), Porazi = int.Parse(porazi) };

            FudbalskaEkipa ekipa2 = new FudbalskaEkipa { Ekipa = ekipa1, NereseniNatprevari = int.Parse(nereseni), ZoltiKartoni = int.Parse(zolti_kartoni) };

            readline_lista_na_fud_ekipi.Add(ekipa2);

            foreach (var item in readline_lista_na_fud_ekipi)
            {
                item.Pecati();
            }
        }
    }
}
