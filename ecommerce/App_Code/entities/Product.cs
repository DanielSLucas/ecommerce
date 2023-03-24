using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Product
/// </summary>
public class Product
{
    // public int id { get; set; }
    public string slug { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public float price { get; set; }

    public Product(string slug, string name, string description, float price)
    {
        this.slug = slug;
        this.name = name;
        this.description = description;
        this.price = price;
    }
}