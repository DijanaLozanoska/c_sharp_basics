using System;
using System.Collections.Generic;

public class NewsArticle
{
    public Category Category { get; set; }

    public string Title { get; set; } = "untitled";


    public NewsArticle()
    {

    }

    public NewsArticle(Category kategorijanavest, string title)
    {
        Category = kategorijanavest;
        Title = title;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {Title}");
        Category.Print();

    }

}