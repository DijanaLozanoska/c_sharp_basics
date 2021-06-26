using System;
using System.Collections.Generic;
using System.Linq;

namespace proba.ZadacaFudbaleri
{
    public class Club : PublicTeam
    {


        public string ImeNaKlub { get; set; }

            public int BrojNaOsvoeniMedali { get; set; }


            public Club()
            {

            }


            public Club(string imeprezimetrener, List<int> golovi, double koeficient, string imenaklub, int brojnaosvoenimedali)
                : base(imeprezimetrener, golovi, koeficient)
            {
                ElementiID++;
                ImeNaKlub = imenaklub;
                BrojNaOsvoeniMedali = brojnaosvoenimedali;

            }


            public override double PromenaNaKoeficient()
            {

                double achievement_klub = 0d;

                foreach (var achievement in Golovi)
                {
                    achievement_klub += achievement;
                }

                return achievement_klub * Koeficient + BrojNaOsvoeniMedali;

            }

            public override void Achievement()
            {

                Console.WriteLine($" Za Trener: " +
                    $"{ImePrezimeTrener} " +
                    $"na Klub: " +
                    $"{ImeNaKlub}: " +
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

            }

        
    }
}
