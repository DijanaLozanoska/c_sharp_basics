using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaFabrika
    {
        public static void FabrikaVoid()
        {
            var readline_list_na_rabotnici = new List<Rabotnik>();
            var readline_fabrika = new Fabrika(readline_list_na_rabotnici);

            Console.Write("Vnesi counter kolku rabotnici ke se vnesat: ");
            var n = Console.ReadLine();
            Console.Write($"Vnesi {n} rabotnici: ");
            Console.WriteLine(" ");
            for (int i = 0; i < Convert.ToInt32(n); i++)
            {
                var split = Console.ReadLine().Split();

                string input_ime = split[0];
                string input_prezime = split[1];
                string input_plata = split[2];

                var add_vo_konstruktor_so_argumenti_rabotnici = new Rabotnik(input_ime, input_prezime, double.Parse(input_plata));
                readline_list_na_rabotnici.Add(add_vo_konstruktor_so_argumenti_rabotnici);
                
            }

            Console.WriteLine(" ");
            Console.Write("Vnesi minimalna plata: ");
            var min = Console.ReadLine();

            readline_fabrika.PecatiVraboteni();
            Console.WriteLine(" ");

            readline_fabrika.PecatiSoPlata(Convert.ToInt32(min));
            Console.WriteLine(" ");

            /*
            var rabotnik0 = new Rabotnik
            {
                Ime = "Mile",
                Prezime = "Palkovski",
                GetPlata = 20000
            };

            var rabotnik1 = new Rabotnik
            {
                Ime = "Kalina",
                Prezime = "Saleska",
                GetPlata = 40720
            };

            var rabotnik2 = new Rabotnik
            {
                Ime = "Aco",
                Prezime = "Noveski",
                GetPlata = 66320
            };

            var lista = new List<Rabotnik>();
            lista.Add(rabotnik0);
            lista.Add(rabotnik1);
            lista.Add(rabotnik2);

            var fabrika = new Fabrika
            {
                BrojNaVraboteni = 3,
                Vraboteni = lista

            };

            fabrika.PecatiVraboteni();
            fabrika.PecatiSoPlata(30000);

            */
        }
    }
}        