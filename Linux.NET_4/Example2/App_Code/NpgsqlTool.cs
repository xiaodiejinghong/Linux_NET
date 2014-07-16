using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// NpgsqlTool 
/// </summary>
public static class NpgsqlTool
{

    private static string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["postgres"].ToString();
    }

    public static DataTable Query(string str)
    {
        DataTable dt = new DataTable();
        using (NpgsqlConnection conn = new NpgsqlConnection())
        {
            conn.ConnectionString = GetConnectionString();
            conn.Open();
            using (NpgsqlDataAdapter nsda = new NpgsqlDataAdapter(str,conn))
            {
                nsda.Fill(dt);
            }
        }
        return dt;
    }

    public static void Execute(string str)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection())
        {
            conn.ConnectionString = GetConnectionString();
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
            }
        }
    }

}