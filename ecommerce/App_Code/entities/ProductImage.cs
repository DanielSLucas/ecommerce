using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ProductImage
/// </summary>
public class ProductImage
{
    // public int id { get; set; }
    public int product_id { get; set; }
    public string filename { get; set; }

    public ProductImage(int product_id, string filename)
    {
        this.product_id = product_id;
        this.filename = filename;
    }
}