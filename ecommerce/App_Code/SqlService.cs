using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Web.Management;

public class SqlService
{
    private SqlConnection con;
    private static SqlService intance = null;

    public SqlService(String connectionString)
    {
        con = new SqlConnection(connectionString);
    }

    public static SqlService getInstance(String connectionString)
    {
        if(getInstance == null)
        {
            intance = new SqlService(connectionString);
        }

        return intance;
    }

    public DataSet executeQuery(String SQL)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        dataAdapter.SelectCommand = new SqlCommand(SQL, con);
        dataAdapter.Fill(ds);
        
        return ds;
    }

    public void executeNonQuery(String SQL)
    {
        SqlCommand cmd = new SqlCommand(SQL, con);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

}