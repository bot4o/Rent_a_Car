using Rent_a_car.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System;

namespace Rent_a_car.Repository
{
    public class Data : IData
    {
        private readonly IConfiguration configuration;
        private readonly string dbcon = "";
        private readonly IWebHostEnvironment webhost;

        public Data(IConfiguration configuration, IWebHostEnvironment webhost)
        {
            this.configuration = configuration;
            dbcon = this.configuration.GetConnectionString("DefaultConnection");
            this.webhost = webhost;
        }

        public bool AddNewCar(Car newcar)
        {
            bool isSaved = false;
            SqlConnection con = GetSqlConnection();
            try
            {
                con.Open();
                string qry = string.Format("INSERT INTO Cars(Brand, Model, Year, Seats, Description, Price) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                            newcar.Brand, newcar.Model, newcar.Year, newcar.Seats, newcar.Description, newcar.Price);
                isSaved = SaveData(qry, con);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Close the connection if it's open
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return isSaved;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(dbcon);
        }

        private bool SaveData(string qry, SqlConnection con)
        {
            bool isSaved = false;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSaved;
        }
    }
}

