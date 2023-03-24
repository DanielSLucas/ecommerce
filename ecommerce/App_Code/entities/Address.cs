using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Address
{
    // public int id { get; set; }
    public string cep { get; set; }
    public string number { get; set; }
    public string street { get; set; }
    public string district { get; set; }
    public string city { get; set; }
    public string uf { get; set; }
    public int user_id { get; set; }

    public Address(string cep, string number, string street, string district, string city, string uf, int user_id)
    {
        this.cep = cep;
        this.number = number;
        this.street = street;
        this.district = district;
        this.city = city;
        this.uf = uf;
        this.user_id = user_id;
    }
}
