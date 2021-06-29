using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaUreduvanjeNaDom
    {
        public static void UreduvanjeDomVoid()
        {
            /*TODO: CONSOLE READLINE INPUT
  
            3   -> input for Vnesi Counter 

            2 4 10 20 Goce_Delcev_20
            1 1 12 43 Pitu_Guli_2
            2 4 10 20 Partizanski_Odredi_87_b
            */


            //so already vneseni

            var lista_na_kukji = new List<Kukja>();

            var masa1 = new Masa { DolzinaM = 2, SirinaM = 4 };
            var soba1 = new Soba { Masa = masa1, DolzinaS = 10, SirinaS = 20 };
            var kukja1 = new Kukja { Adresa = "Goce_Delcev_10", Soba = soba1, Kukji = lista_na_kukji };

            lista_na_kukji.Add(kukja1);

            kukja1.Pecati();

            // so console readline

            var readline_lista_na_kukji = new List<Kukja>();

            Console.Write("Vnesi counter: ");  // counter 1
            var total_kolku_kukji_ke_se_vnesat = Console.ReadLine();

            for (int i = 0; i < Convert.ToInt32(total_kolku_kukji_ke_se_vnesat); i++)
            {
                var input = Console.ReadLine();
                var split_na_red = input.Split();

                var input_na_masa_dolzina = split_na_red[0];
                var input_na_masa_sirina = split_na_red[1];
                var input_na_soba_dolzina = split_na_red[2];
                var input_na_soba_sirina = split_na_red[3];
                var input_na_adresa = split_na_red[4];


                var add_vo_constructor_so_argumenti_masa = new Masa
                    (
                    int.Parse(input_na_masa_dolzina),
                    int.Parse(input_na_masa_sirina)
                    );


                var add_vo_constructor_so_argumenti_soba = new Soba
                    (
                    add_vo_constructor_so_argumenti_masa,
                    int.Parse(input_na_soba_dolzina),
                    int.Parse(input_na_soba_sirina)
                    );


                var add_vo_constructor_so_argumenti_kukja = new Kukja
                    (
                    input_na_adresa,
                    add_vo_constructor_so_argumenti_soba,
                    readline_lista_na_kukji
                    );

                readline_lista_na_kukji.Add(add_vo_constructor_so_argumenti_kukja);


            }


            foreach (var kukji in lista_na_kukji)
            {
                kukji.Pecati();
            }


            Console.WriteLine("Done");

        }
    }
}
