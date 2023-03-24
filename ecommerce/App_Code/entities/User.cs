using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de User
/// </summary>
public class User
{
    // public int id { get; set; }
    public string name { get; set; }
    public string cpf { get; set; }
    public string tel { get; set; }
    public bool is_adm { get; set; }
    public string password { get; set; }
    public string email { get; set; }

    public User(string name, string cpf, string tel, bool is_adm, string password, string email)
    {
        this.name = name;
        this.cpf = cpf;
        this.tel = tel;
        this.is_adm = is_adm;
        this.password = password;
        this.email = email;
    }
}