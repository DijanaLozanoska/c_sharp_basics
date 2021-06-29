using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaSportskiEkipi
    {
        public static void SportskiEkipiVoid()
        {
            // tuka ima greska (treba da se resi isto kako NBA nasleduvanjeto)
            // na net da ja pobaram ja ima celosna verzija (so poveke raboti da se vnesat)
            var ekipa = new Ekipa { Ime = "Fudbaleri", Pobedi = 5, Porazi = 4 };

            var ekipa_lista = new List<Ekipa>();
            ekipa_lista.Add(ekipa);

            var fudbalska_ekipa = new FudbalskaEkipa { Ekipi = ekipa_lista, NereseniNatprevari = 6, Pobedi = 7 };

            var fudbalska_ekipa_lista = new List<FudbalskaEkipa>();
            fudbalska_ekipa_lista.Add(fudbalska_ekipa);

            foreach (var item in fudbalska_ekipa_lista)
            {
                item.Pecati();
                fudbalska_ekipa.Poeni();
            }
        }
    }
}
