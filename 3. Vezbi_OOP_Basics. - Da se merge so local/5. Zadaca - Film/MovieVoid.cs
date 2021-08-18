using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaFilm
    {
        public static void FilmVoid()
        {

            /*TODO: CONSOLE READLINE INPUT

            4

            Frankenweenie
            Tim_Burton
            Animation
            2012

            Lincoln
            Steven_Spielberg
            History
            2012

            Wall-E
            Andrew_Stanton
            Animation
            2008

            Avatar
            James_Cameron
            Fantasy
            2009

            2012

             */

            /* proba dali e OK so already vneseni

            var lista = new List<Movie>() { new Movie(
                "Frankenweenie",
                "Tim_Burton",
                "Animation",
                2012
                ) };

            pecati_po_godina(lista, 2012);

            static void pecati_po_godina(List<Movie> movies, int godina)
            {
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].GetGodina() == godina)
                    {
                        movies[i].Print();
                    }
                }

            */


            //// so console.readline

            var readline_lista_na_filmovi = new List<Movie>();

            Console.Write("Vnesi counter kolku filmovi ke se vnesat: ");

            var n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Vnesi film" + " " + (i + 1) + " " + "ime: ");
                var input_ime = Console.ReadLine();

                Console.Write("Vnesi film" + " " + (i + 1) + " " + "reziser: ");
                var input_reziser = Console.ReadLine();

                Console.Write("Vnesi film" + " " + (i + 1) + " " + "zanr: ");
                var input_zanr = Console.ReadLine();

                Console.Write("Vnesi film" + " " + (i + 1) + " " + "godina: ");
                var input_godina = Console.ReadLine();
                Console.WriteLine("\n");

                var add_vo_konstruktor_so_argumenti_filmovi = new Movie(input_ime, input_reziser, input_zanr, int.Parse(input_godina));
                readline_lista_na_filmovi.Add(add_vo_konstruktor_so_argumenti_filmovi);
            }

            Console.Write("Vnesi filter/godina za filmovi: ");
            var godina_filter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            static void pecati_po_godina(List<Movie> movies, int godina)
            {
                foreach (var movie in movies)
                {
                    if (movie.GetGodina() == godina)
                    {
                        movie.Print();
                        Console.WriteLine(" ");
                    }
                }
            }

            Console.WriteLine($"*** Lista na filmovi od {godina_filter} ***");
            pecati_po_godina(readline_lista_na_filmovi, godina_filter);
            Console.WriteLine("Done");
        }
    }
}
