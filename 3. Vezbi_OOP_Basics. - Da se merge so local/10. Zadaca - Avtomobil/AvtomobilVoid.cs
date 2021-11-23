using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaAvtomobil
    {
        public static void AvtomobilVoid()
        {

            var readline_list_na_car = new List<Car>();

            Console.Write("Vnesi counter kolku luge ke se vnesat: ");
            var n = Console.ReadLine();


            Console.WriteLine(" ");

            for (int i = 0; i < Convert.ToInt32(n); i++)
            {
                Console.Write("Vnesi covek" + " " + (i + 1) + " " + "ime: ");
                var input_ime = Console.ReadLine();

                Console.Write("Vnesi covek" + " " + (i + 1) + " " + "prezime: ");
                var input_prezime = Console.ReadLine();

                Console.Write("Vnesi covek" + " " + (i + 1) + " " + "godina: ");
                var input_godina = Console.ReadLine();

                Console.Write("Vnesi covek" + " " + (i + 1) + " " + "mesec: ");
                var input_mesec = Console.ReadLine();

                Console.Write("Vnesi covek" + " " + (i + 1) + " " + "den: ");
                var input_den = Console.ReadLine();

                Console.Write("Vnesi covek" + " " + (i + 1) + " " + "cena: ");
                var input_cena = Console.ReadLine();

                var car = new Car() { Sopstvenik =
                    new Person(input_ime, input_prezime),
                    Cena = int.Parse(input_cena),
                    DatumNaKupuvanje = new Datum(
                    int.Parse(input_godina),
                    int.Parse(input_mesec),
                    int.Parse(input_den)) };

                readline_list_na_car.Add(car);
            }

            Console.WriteLine(" ");
            Console.Write("Vnesi minimalna cena: ");
            var min = Console.ReadLine();

            CheaperThan(readline_list_na_car , Convert.ToInt32(min));
            Console.WriteLine(" ");


            /*
            var avtomobil = new Car() { Sopstvenik = new Person("Riste", "Risteski"), Cena = 30000, DatumNaKupuvanje = new Datum(2021, 01, 01) };
            var avtomobil1 = new Car() { Sopstvenik = new Person("Di", "Lo"), Cena = 10000, DatumNaKupuvanje = new Datum(2020, 12, 31) };

            var lista = new List<Car>() {avtomobil, avtomobil1};

            CheaperThan(lista, 20000);
            */
        }

        public static void CheaperThan(List<Car> cars, float price) //int numCars,
        {
            for (int i = 0; i < cars.Count; i++) // so for loop bez int numCars
            {
                if (cars[i].Cena < price)
                {
                    cars[i].Print();
                }
            }

            //for (int i = 0; i < numCars; i++) // so int numCars
            //{
            //    if (cars[i].Cena < price)
            //    {
            //        cars[i].Print();
            //    }
            //}

            //foreach (var car in cars) // so foreach 
            //{
            //    if (car.Cena < price)
            //    {
            //        car.Print();
            //    }
            //}
        }
    }
}
