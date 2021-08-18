using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaKrug
    {
        public static void KrugVoid()
        {
            var output1 = new Circle(5f);
            Console.WriteLine(Circle.GetArea(output1));

     
            var output2 = new Circle(5f);
            //Console.WriteLine(Circle.GetPerimeter(output2));
            Console.WriteLine($"{Circle.GetPerimeter(output2):0.00}");


            if (output1 == output2) // compare area and perimeter
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
