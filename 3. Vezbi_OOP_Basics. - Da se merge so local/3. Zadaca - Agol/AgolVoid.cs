using System;
using System.Collections.Generic;

namespace Vezbi_OOP_Basics
{
    public class ZadacaAgol
    {
        public static void AgolVoid()
        {
            var output1 = new Angle(180);
            Console.WriteLine($"The value of given degrees converted into seconds equals to : " + (Angle.CalculateAngleInSeconds(output1)));


            var output2 = new Angle(180, 0, 60);
            if (Angle.DataValidationOfTheAngle(output2))
            {
                Console.WriteLine($"The value of {output2.degrees} degrees, {output2.minutes} minutes, {output2.seconds} seconds is valid");
            }
            else
            {
                Console.WriteLine($"The value of {output2.degrees} degrees, {output2.minutes} minutes, {output2.seconds} seconds is not valid");
            }
        }
    }
}
