using System;
using System.Collections.Generic;

public class NewsArticle
{
    public Category KategorijaNaVest { get; set; }

    public string Naslov { get; set; }


    public NewsArticle()
    {
        KategorijaNaVest = new Category();
        Naslov = "untitled";
    }

    public NewsArticle(Category kategorijanavest, string naslov)
    {
        KategorijaNaVest = kategorijanavest;
        Naslov = naslov;
    }

    public void Print()
    {
        Console.WriteLine($"Naslov: {Naslov}");
        KategorijaNaVest.Print();

    }

}