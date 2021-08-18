using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaDogovor
    {
        public static void DogovorVoid()
        {
            /*TODO: CONSOLE READLINE INPUT

            1
            0101988450001 Alek Aleksov
            0101988450001 Alek Aleksov
            0202987440022 Marko Markov

           */

            //proba dali e OK so already vneseni
            //var potpisuvac1 = new Potpisuvac() { Ime = "Alek", Prezime = "Aleksov", EMBG = 0101988450001d };
            //var potpisuvac2 = new Potpisuvac() { Ime = "Alek", Prezime = "Aleksov", EMBG = 0101988450001d };
            //var potpisuvac3 = new Potpisuvac() { Ime = "Marko", Prezime = "Markov", EMBG = 0202987440022d };

            //var main_lista_na_potpisuvaci = new List<Potpisuvac>();
            //main_lista_na_potpisuvaci.Add(potpisuvac1);
            //main_lista_na_potpisuvaci.Add(potpisuvac2);
            //main_lista_na_potpisuvaci.Add(potpisuvac3);

            //var dogovor1 = new Dogovor { BrojNaDogovor = 1, KategorijaNaDogovor = main_lista_na_potpisuvaci };

            //if (Dogovor.ProveriDupliEMBG(main_lista_na_potpisuvaci))
            //{
            //    Console.WriteLine("Postojat potpishuvaci so ist EMBG");
            //}
            //else
            //{
            //    Console.WriteLine("Ne postojat potpishuvaci so ist EMBG");
            //}
            //Console.WriteLine("Done");


            //// so console.readline

            var readline_lista_na_potpisuvaci = new List<Potpisuvac>();

            Console.Write("Vnesi counter kolku dogovori ke se vnesat: ");
            var total_kolku_dogovori_ke_se_vnesat = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < total_kolku_dogovori_ke_se_vnesat; i++)
            {
                Console.Write("Vnesi broj na dogovor: ");
                var input_broj_na_dogovor = Console.ReadLine();

                Console.WriteLine("Vnesi 3 (tri) potpisuvaci");
                for (int j = 0; j < 3; j++)
                {
                    var split = Console.ReadLine().Split();

                    string input_embg = split[0];
                    string input_ime = split[1];
                    string input_prezime = split[2];

                    var add_vo_konstruktor_so_argumenti_potpisuvaci = new Potpisuvac(input_ime, input_prezime, double.Parse(input_embg));
                    readline_lista_na_potpisuvaci.Add(add_vo_konstruktor_so_argumenti_potpisuvaci);

                }

                var add_vo_konstruktor_so_argumenti_dogovor = new Dogovor(int.Parse(input_broj_na_dogovor), readline_lista_na_potpisuvaci);

                if (Dogovor.ProveriDupliEMBG(readline_lista_na_potpisuvaci))
                {
                    Console.WriteLine("Postojat potpishuvaci so ist EMBG");
                }
                else
                {
                    Console.WriteLine("Ne postojat potpishuvaci so ist EMBG");
                }

                Console.WriteLine("Done");
            }
        }
    }
}
   