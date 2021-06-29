using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaNaslovna
    {
        public static void NaslovnaVoid()
        {
            var front_page = new FrontPage
            {
                Price = 2012,
                EditionNumber = 1,
                NaslovnaVest = new NewsArticle
                {
                    Naslov = "Born To Die ",
                    KategorijaNaVest = new Category
                    { Name = "Lana Del Rey" }
                }
            };

            front_page.Print();
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
