using System;
using System.Collections.Generic;

public class FrontPage
{

    public NewsArticle NewsArticle { get; set; }

    public float Price { get; set; } = 0;

    public int EditionNumber { get; set; } = 0;


    public FrontPage()
    {

    }

    public FrontPage(NewsArticle newsarticle, float price, int editionnumber)
    {
        NewsArticle = newsarticle;
        Price = price;
        EditionNumber = editionnumber;
    }


    public void Print()
    {
        Console.WriteLine($"Price: {Price}, Edition Number {EditionNumber} ");
        NewsArticle.Print();

    }

}
