using System;
using System.Collections.Generic;

public class Angle
{
    public int degrees { get; set; }
    public int minutes { get; set; }
    public int seconds { get; set; }

    public Angle(int degrees1) // for calculation of seconds
    {
        this.degrees = degrees1;
    }

    public Angle(int degrees1, int minutes1, int seconds1)
    {
        this.degrees = degrees1;
        this.minutes = minutes1;
        this.seconds = seconds1;
    }

    public Angle()
    {

    }

    // Method 1: Calculate the seconds " of the input in degrees if 1° (degree)  = 60' (minutes) = 3600" (seconds)
    public static int CalculateAngleInSeconds(Angle degrees2)
    {
        var mycalculation = (degrees2.degrees * 3600);
        return mycalculation;
    }


    // Method 2: (if the value of the input angle is OK)
    //(degrees >= 0 && degrees <= 360) && (minutes >= 0&& minutes <= 60) && (seconds >= 0 && seconds <= 60) return ako se OK 
    public static bool DataValidationOfTheAngle(Angle angle)
    {
        bool result = false;
        {
            if ((angle.degrees >= 0 && angle.degrees <= 360) && (angle.minutes >= 0 && angle.minutes <= 60) && (angle.seconds >= 0 && angle.seconds < 60))
            {
                result = true;
            }

            return result;
        }
    }
}
       