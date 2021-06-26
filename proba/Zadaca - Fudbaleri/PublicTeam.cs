using System;
using System.Collections.Generic;

namespace proba.ZadacaFudbaleri
{

        public abstract class PublicTeam
        {

            public string ImePrezimeTrener { get; set; }

            public List<int> Golovi { get; set; }

            public int ElementiID = 0;

            public double Koeficient { get; set; }


            public PublicTeam()
            {

            }


            public PublicTeam(string imeprezimetrener, List<int> golovi, double koeficient)
            {
                ImePrezimeTrener = imeprezimetrener;
                Golovi = golovi;
                Koeficient = koeficient;
                ElementiID++;

            }


            public abstract double PromenaNaKoeficient();

            public abstract void Achievement();

            public abstract void GreatestAchievement(List<PublicTeam> listpublicteam);

            public abstract void Count(List<PublicTeam> listpublicteam, int elementid);


        }
    
}
