using System;
using System.Collections.Generic;

public class Circle
{
    public float radius { get; set; }
    const float _pi = 3.14f;

    public Circle() // default constructor 
    {

    }

    public static float Pi // constructor with arguments
    {
        get { return _pi; }

    }

    public Circle(float radius1) //  constructor with arguments
    {
        radius = radius1;
    }


    public static float GetArea(Circle circle) // method 1 
    {
        var getarea = Pi * (circle.radius * circle.radius);
        return getarea;
    }

    public static decimal GetPerimeter(Circle circle1) // method 2
    {
        var getperimeter = (2 * circle1.radius * Pi);
        return (decimal)Math.Round(getperimeter);
    }
}

