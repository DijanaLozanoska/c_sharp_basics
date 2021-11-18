using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaNedviznina
    {
        public static void NedvizninaVoid()
        {
            /*TODO: CONSOLE READLINE INPUT
  
            Kukja_vo_Centar
            60
            850
            Vila_na_Vodno
            110
            1120
            10

            */

            
            Console.WriteLine("***   Input za Nedviznina   ****");
            Console.Write("Vnesi Adresa: ");
            string inputadresa = Console.ReadLine();
            Console.Write("Vnesi Kvadratura: ");
            string inputkvadratura = Console.ReadLine();
            Console.Write("Vnesi cena po kvadrat: ");
            string inputcenapokvadrat = Console.ReadLine();

            var nedviznina = new Nedviznina(inputadresa, inputkvadratura, inputcenapokvadrat);
            Console.WriteLine();
            Console.WriteLine("***   Output za Nedviznina   ***");
            nedviznina.Pecati();
            nedviznina.DanokNaImot();

            

            Console.WriteLine("***   Output za Vila   ***");
            Console.Write("Vnesi Adresa: ");
            string inputadresa1 = Console.ReadLine();
            Console.Write("Vnesi Kvadratura: ");
            string inputkvadratura1 = Console.ReadLine();
            Console.Write("Vnesi cena po kvadrat: ");
            string inputcenapokvadrat1 = Console.ReadLine();
            Console.Write("Vnesi ddv: ");
            string inputdanoknaluksuz = Console.ReadLine();

            var vila = new Vila(inputadresa1, inputkvadratura1, inputcenapokvadrat1, inputdanoknaluksuz);
            Console.WriteLine();

            Console.WriteLine("***   Output za Vila   ***");
            vila.Pecati();
            vila.DanokNaImot();

        }
    }
}
