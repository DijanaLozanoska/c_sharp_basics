using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaAvtomobil
    {
        public static void AvtomobilVoid()
        {
             /*TODO: CONSOLE READLINE INPUT  
              * 
              */

            var avtomobil = new Car() { Sopstvenik = new Person("Riste", "Risteski"), Cena = 30000, DatumNaKupuvanje = new Datum(2021, 01, 01) };
            var avtomobil1 = new Car() { Sopstvenik = new Person("Di", "Lo"), Cena = 10000, DatumNaKupuvanje = new Datum(2020, 12, 31) };

            //avtomobil.Print();  probno

            var lista = new List<Car>() { avtomobil, avtomobil1 };

            CheaperThan(lista, 20000);


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
