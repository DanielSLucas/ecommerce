using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ProductCategory
/// </summary>
public class ProductCategory
{
    // public int id { get; set; }
    public int product_id { get; set; }
    public int category_id { get; set; }

    public ProductCategory(int product_id, int category_id)
    {
        this.product_id = product_id;
        this.category_id = category_id;
    }
}