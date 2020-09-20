﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Repository
{
    public class RepositoryClass
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\achas\Documents\CompaniesDB.mdf;Integrated Security=True;Connect Timeout=30");


        public string DoStuff(string json)
        {
            var companyEntity = JsonConvert.DeserializeObject<CompanyEntity>(json); // would be replaced with some actual logic

            try
            {
                SqlCommand command = new SqlCommand("Company_Add", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", companyEntity.Id);
                command.Parameters.AddWithValue("@Name", companyEntity.Name);
                command.Parameters.AddWithValue("@Address", companyEntity.Address);
                command.Parameters.AddWithValue("@Www", companyEntity.Www);
                command.Parameters.AddWithValue("@Nip", companyEntity.Nip);
                command.Parameters.AddWithValue("@Phone", companyEntity.Phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return "Company record added!";
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return ex.Message.ToString();
            }
        }

        public List<CompanyEntity> GetAllCompanies()
        {
            try
            {
                SqlCommand command = new SqlCommand("Company_GetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                                
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var myList = new List<CompanyEntity>();

                while (reader.Read())
                {

                    var record = new CompanyEntity(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    myList.Add(record);
                }

                connection.Close();

                return myList;
            }
            catch (Exception)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw;
            }

        }
    }
}