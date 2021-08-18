using System;
using System.Collections.Generic;
using System.Linq;

public class Dogovor
{
    public int BrojNaDogovor { get; set; }

    public List<Potpisuvac> KategorijaNaDogovor { get; set; }

    public Potpisuvac Potpisuvac { get; set; }


    public Dogovor()
    {

    }

    public Dogovor(int inputbrojnadogovor, List<Potpisuvac> readlinelista)
    {
        BrojNaDogovor = inputbrojnadogovor;
        KategorijaNaDogovor = readlinelista;
    }


    public static bool ProveriDupliEMBG(List<Potpisuvac> kategorija_na_dogovor)
    {
        bool result = false;

        List<double> dupli_embg = new List<double>();

        foreach (var item in kategorija_na_dogovor)
        {
            var embg = item.EMBG;
            dupli_embg.Add(embg);
            dupli_embg.Sort();

            for (int i = 1; i < dupli_embg.Count; i++)
            {
                if (dupli_embg[i] == dupli_embg[i - 1])
                {
                    result = true;
                }
            }
            }

        return result;
    }
}
