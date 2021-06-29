using System;
using System.Collections.Generic;

public class Category
{
    public string Name { get; set; }

    public Category()
    {
        Name = "unnamed";
    }

    public void Print()
    {
        Console.WriteLine($"Name: {Name}");
    }
}
