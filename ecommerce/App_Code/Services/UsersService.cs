using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

public class UsersService
{
    private static SqlService sqlService = new SqlService(
        ConfigurationManager.ConnectionStrings["ecom_db"].ConnectionString
    );
    private static BaseRepository<User> usersRepository = new BaseRepository<User>("user", sqlService);
    public DataSet listAll()
    {
        return usersRepository.listAll();
    }

    public DataSet findById(int id)
    {
        return usersRepository.findById(id);
    }

    public String create(string name, string cpf, string tel, bool is_adm, string password, string email)
    {
        User user = new User(name, cpf, tel, is_adm, password, email);

        return usersRepository.create(user);
    }

    public String update(int id, string name, string cpf, string tel, bool is_adm, string password, string email)
    {
        User user = new User(name, cpf, tel, is_adm, password, email);

        return usersRepository.update(id, user);
    }
    
    public String delete(int id)
    {
        return usersRepository.delete(id);
    }
}