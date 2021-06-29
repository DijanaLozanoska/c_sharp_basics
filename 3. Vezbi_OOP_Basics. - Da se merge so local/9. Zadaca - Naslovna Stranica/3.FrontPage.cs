using System;
using System.Collections.Generic;

public class FrontPage
{

    public NewsArticle NaslovnaVest { get; set; }

    public float Price { get; set; }

    public int EditionNumber { get; set; }


    public FrontPage()
    {
        NaslovnaVest = new NewsArticle();
        Price = 0;
        EditionNumber = 0;

    }

    public FrontPage(NewsArticle newsarticle, float price, int editionnumber)
    {
        NaslovnaVest = newsarticle;
        Price = price;
        EditionNumber = editionnumber;
    }

    public void Print()
    {
        Console.WriteLine($"Price: {Price}, Edition Number {EditionNumber} ");
        NaslovnaVest.Print();

    }

}
