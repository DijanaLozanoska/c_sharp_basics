using System;
using System.Collections.Generic;
using System.Linq;
using proba.ZadacaFudbaleri;

namespace proba.ZadacaFudbaleri
{
    public class FudbaleriVoid
    {
        public static void FudbaleriVoid1()
        {
            // zadaca fudbaleri 

            //  Derived class: Club 1 //

            var golovi_club1 = new List<int>();
            golovi_club1.Add(2);
            golovi_club1.Add(5);
            golovi_club1.Add(0);
            golovi_club1.Add(1);


            var club1 = new Club()
            {
                ImePrezimeTrener = "Kris Jenner",
                Golovi = golovi_club1,
                Koeficient = 2.0,
                ImeNaKlub = "Calabasas",
                BrojNaOsvoeniMedali = 1,


            };


            //  Derived class: National Team 1 i National Team 2//

            var golovi_national_team1 = new List<int>();
            golovi_national_team1.Add(2);
            golovi_national_team1.Add(5);
            golovi_national_team1.Add(0);
            golovi_national_team1.Add(1);


            var national_team1 = new NationalTeam()
            {
                ImePrezimeTrener = "Kim Kardashian",
                Golovi = golovi_national_team1,
                Koeficient = 2.0,
                MegunarodniNastapi = 3,
                ZemjaNaReprezentacija = "Los Angeles",



            };

            var golovi_national_team2 = new List<int>();
            golovi_national_team2.Add(2);
            golovi_national_team2.Add(4);
            golovi_national_team2.Add(0);
            golovi_national_team2.Add(2);


            var national_team2 = new NationalTeam()
            {
                ImePrezimeTrener = "Kourtney Kardashian",
                Golovi = golovi_national_team2,
                Koeficient = 4.0,
                MegunarodniNastapi = 6,
                ZemjaNaReprezentacija = "Malibu",


            };


            // Base class: Public team  //


            var lista_public_team = new List<PublicTeam>();
            lista_public_team.Add(club1);
            lista_public_team.Add(national_team1);
            lista_public_team.Add(national_team2);


            // test na achievement funkcija output

            //foreach (var item in lista_public_team)
            //{
            //item.Achievement();
            //}

            Console.WriteLine(" ");


            //Funkcija Greatest Achievement//

            var sortirana_lista_lista_public_team = lista_public_team.OrderByDescending(x => x.PromenaNaKoeficient()).ToList();

            foreach (var item in sortirana_lista_lista_public_team)
            {

                item.GreatestAchievement(sortirana_lista_lista_public_team);
                // imam greska site mi gi dava namesto samo prvoto 

            }

            Console.WriteLine(" ");

            // Funkcija count po distinct lista //

            Console.WriteLine();
            Console.WriteLine("Distinct count po type na lista e");
            var count_distinct_na_lista = lista_public_team.ToLookup(x => x.GetType());
            count_distinct_na_lista.Count();

            foreach (var distinct in count_distinct_na_lista)
            {
                Console.WriteLine($"Vo taa lista ima tolku vlezovi: {distinct.Count()}");
                // isto i tuka imam greska posto neznam kako da gi povikam site vlezovi  

            }

        }

    }

}
