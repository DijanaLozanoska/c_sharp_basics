using System;
using System.Collections.Generic;
using System.Linq;

namespace proba.ZadacaFudbaleri
{
    public class NationalTeam : PublicTeam
    {
  
            public string ZemjaNaReprezentacija { get; set; }

            public int MegunarodniNastapi { get; set; }


            public NationalTeam()
            {

            }


            public NationalTeam(string imeprezimetrener, List<int> golovi, double koeficient, string zemjanareprezentacija, int megunarodninastapi)
                : base(imeprezimetrener, golovi, koeficient)
            {
                ElementiID++;
                ZemjaNaReprezentacija = zemjanareprezentacija;
                MegunarodniNastapi = megunarodninastapi;

            }



            public override double PromenaNaKoeficient()
            {

                double achievement_klub = 0d;

                foreach (var achievement in Golovi)
                {
                    achievement_klub += achievement;
                }

                return achievement_klub * Koeficient + MegunarodniNastapi;

            }


            public override void Achievement()
            {

                Console.WriteLine($" Za Trener: " +
                                   $"{ImePrezimeTrener} " +
                                   $"za zemja na reprezentacija: " +
                                   $"{ZemjaNaReprezentacija} " +
                                   $"Achievement e: " +
                                   $"{PromenaNaKoeficient()}");

            }


            public override void GreatestAchievement(List<PublicTeam> listpublicteam)
            {

                var elementlist = listpublicteam.ElementAt(0);

                Console.WriteLine($"Trener so najgolemo dostignuvanje e {elementlist.ImePrezimeTrener} so dostignuvanje od: {elementlist.PromenaNaKoeficient()} ");

            }

            public override void Count(List<PublicTeam> listpublicteam, int elementid)
            {
                for (int i = 0; i < elementid; i++)
                {

                }

            }


        


    }

}

