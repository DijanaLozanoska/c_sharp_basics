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
                NewsArticle = new NewsArticle
                {
                    Title = "Born To Die ",
                    Category = new Category
                    { Name = "Lana Del Rey" }
                }
            };

            front_page.Print();
        }
    }
}
