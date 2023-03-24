using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Cart
/// </summary>
public class Cart
{
    // public int Id { get; set; }
    public bool is_active { get; set; }
    public int user_id { get; set; }

    public Cart(bool is_active, int user_id)
    {
        this.is_active = is_active;
        this.user_id = user_id;
    }
}