using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using MyDataAccessLayer.Entity;

namespace MyDataAccessLayer
{
    public class CricketersDetailsRepository:ICricketersDetailsRepository
    {
        string connectionString = null;//"server=DESKTOP-BLBGEHJ\\SQLEXPRESS;database=Cricketerslist;user Id=sa;password=Anaiyaan@123;";
        SqlConnection con = null;

        public CricketersDetailsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
            con = new SqlConnection(connectionString);
        }
        public List<CricketDetails> SelectALLUser()
        {
            try
            {
                var selectQuery = $"exec SelectAllUser";
                con.Open();
                List<CricketDetails> result = con.Query<CricketDetails>(selectQuery).ToList();
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CricketDetails SelectUserByUsername(string username)
        {
            try
            {
                var selectQuery = $"exec selectusingname '{username}'";
                con.Open();
                CricketDetails result = con.QueryFirstOrDefault<CricketDetails>(selectQuery);
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RegisterUser(CricketDetails cric)
        {
            try
            {
                var insertQuery = $"exec insertusername '{cric.CricketerName}',{cric.Totalinnings},{cric.TotalScore},'{cric.DateOfBirth}',{cric.NumberOfFifties},{cric.NumberOfHundreds},{cric.HighestScore}";
                con.Open();
                con.Execute(insertQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                
              throw;
            }
        }

        public void UpdateUser(CricketDetails value)
        {
            try
            {
                var updateQuery = $"exec Updateusername {value.CricketersID},'{value.CricketerName}',{value.Totalinnings},{value.TotalScore},'{value.DateOfBirth}',{value.NumberOfFifties},{value.NumberOfHundreds},{value.HighestScore}";
                //var connectionString = "server=DESKTOP-8VD1A1F\\SQLEXPRESS;database=batch9;user Id =sa;password=Anaiyaan@123;";

                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void DeleteUser(long Id)
        {
            try
            {
                var updateQuery = $"exec Deleteusername {Id}";
                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
