using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace mvcagain.Models
{
    public class BookstoreDb : IBookstoreDb
    {
        private string _connectionString = Properties.Settings.Default.connectionString;

        public IEnumerable<Publisher> GetPublishers()
        {
            using (var dbcon = new SqlConnection(_connectionString))
            {
                //dbcon.Open();

                return dbcon.Query<Publisher>("select * from publishers");
            }
        }


    }
}