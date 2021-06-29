using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaNBAPlayer
    {
        public static void NBAPlayerVoid()
        {
            /*Test
              var test_nba_player = new NBAPlayer() { Ime = "Steph Curry", Tim = "Golden State Warriors", Poeni = 33d, Asistencii = 44d, Skokovi = 55d };
              var test_all_star_player = new AllStarPlayer(test_nba_player, 11d, 22d,  33d);
              var test_list = new List<AllStarPlayer>();
              test_list.Add(test_all_star_player);
              foreach (var test_player in test_list)
              {
                  test_player.Print();
              } 
            */

            var nba_player1 = new NBAPlayer() { Ime = "Nikola_Jokic", Tim = "Denver_Nuggets", Poeni = 18.3, Asistencii = 6.1, Skokovi = 10.6 };
            var nba_player2 = new NBAPlayer() { Ime = "Lonzo_Ball", Tim = "Los_Angeles_Lakers", Poeni = 10.2, Asistencii = 7.2, Skokovi = 6.9 };
            var nba_player3 = new NBAPlayer() { Ime = "Donovan_Mitchell", Tim = "Utah_Jazz", Poeni = 20.4, Asistencii = 3.6, Skokovi = 3.7 };
            var nba_player4 = new NBAPlayer() { Ime = "Ben_Simmons", Tim = "Philadelphia_76ers", Poeni = 16, Asistencii = 8.2, Skokovi = 8.2 };
            var nba_player5 = new NBAPlayer() { Ime = "Kristaps_Porzingis", Tim = "NewYork_Knicks", Poeni = 22.7, Asistencii = 1.2, Skokovi = 6.6 };


            var all_star_nba_player1 = new AllStarPlayer(nba_player1, 1, 2, 3);
            var all_star_nba_player2 = new AllStarPlayer(nba_player2, 4, 5, 6);
            var all_star_nba_player3 = new AllStarPlayer(nba_player3, 7, 8, 9);
            var all_star_nba_player4 = new AllStarPlayer(nba_player4, 10, 11, 12);
            var all_star_nba_player5 = new AllStarPlayer(nba_player5, 13, 14, 15);


            var lista_na_all_star = new List<AllStarPlayer>();
            lista_na_all_star.Add(all_star_nba_player1);
            lista_na_all_star.Add(all_star_nba_player2);
            lista_na_all_star.Add(all_star_nba_player3);
            lista_na_all_star.Add(all_star_nba_player4);
            lista_na_all_star.Add(all_star_nba_player5);


            foreach (var player in lista_na_all_star)
            {
                player.Print();
            }


            Console.WriteLine("Done");

        }
    }
}
