using System;
using System.Collections.Generic;
using System.Linq;
using proba.ZadacaFudbaleri;

namespace proba
{

    // Main Program   
    class mcStart
    {
        public static void Main(string[] args)
        {
            mcCalculator mcCal = new mcCalculator(50);
            mcCal.add(12, 23);
            mcCal.displayiOutVal();
            mcCal.subtract(24, 4);
            mcCal.displayiOutVal();
            mcCal.Multiply(12, 3);
            mcCal.displayiOutVal();
            mcCal.Divide(8, 2);
            mcCal.displayiOutVal();



            //FudbaleriVoid new_new = new FudbaleriVoid();
            FudbaleriVoid.FudbaleriVoid1();

        }


    }
}