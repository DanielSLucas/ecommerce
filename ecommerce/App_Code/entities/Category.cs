using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Category
/// </summary>
public class Category
{
    // public int id { get; set; }
    public string name { get; set; }

    public Category(string name)
    {
        this.name = name;        
    }
}