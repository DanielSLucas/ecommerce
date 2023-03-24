using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de CartProduct
/// </summary>
public class CartProduct
{
    // public int Id { get; set; }
    public int cart_id { get; set; }
    public int product_id { get; set; }

    public CartProduct(int cart_id, int product_id)
    {
        this.cart_id = cart_id;
        this.product_id = product_id;
    }
}