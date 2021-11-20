using System;
using System.Collections.Generic;

public class Category
{
    public string Name { get; set; } = "unnamed";

    public Category()
    {
        
    }

    public void Print()
    {
        Console.WriteLine($"Category: {Name}");
    }
}
