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

        public void Create(Book x) { throw new NotImplementedException(); }
        public void Create(Publisher x) { throw new NotImplementedException(); }


        public void Update(Book x) { throw new NotImplementedException(); }


        public void Update(Publisher x) { throw new NotImplementedException(); }


        public void Delete(Book x) { throw new NotImplementedException(); }


        public void Delete(Publisher x) { throw new NotImplementedException(); }



    }
}