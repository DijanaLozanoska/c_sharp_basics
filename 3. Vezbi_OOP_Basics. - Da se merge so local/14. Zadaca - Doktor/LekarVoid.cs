using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaDoktor
    {
        public static void DoktorVoid()
        {
            Console.WriteLine("====== Testiranje na klasata lekar =======");
            Console.Write("Vnesi broj na lekari: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var kotizacija = new List<decimal>();
                MaticenLekar lekar;
                Console.WriteLine($"Vnes na {i + 1} lekar");
                Console.Write("Vnesi faksimil");
                int faksimil = int.Parse(Console.ReadLine());
                Console.WriteLine("Vnesi ime");
                string ime = Console.ReadLine();
                Console.WriteLine("Vnesi prezime");
                string prezime = Console.ReadLine();
                Console.WriteLine("Vnesi pocetna plata");
                decimal pplata = decimal.Parse(Console.ReadLine());
                int brPacienti = int.Parse(Console.ReadLine());
                for (int j = 0; j < brPacienti; j++)
                {
                    Console.Write($"Vnesi {i + 1} kotizacija");
                    kotizacija.Add(decimal.Parse(Console.ReadLine()));
                }

                lekar = new MaticenLekar(ime, prezime, faksimil, pplata, brPacienti, kotizacija);
                lekar.Pecati();
            }
        }
    }
}
