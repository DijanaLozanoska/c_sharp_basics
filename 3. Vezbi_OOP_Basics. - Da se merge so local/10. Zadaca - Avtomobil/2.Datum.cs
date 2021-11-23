using System;
using System.Collections.Generic;

public class Datum
{
    public int Year { get; set; }

    public int Month { get; set; }

    public int Day { get; set; }

    public Datum()
    {

    }

    public Datum(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public void Print()
    {
        Console.WriteLine($"{Year}.{Month}.{Day}");
    }
}