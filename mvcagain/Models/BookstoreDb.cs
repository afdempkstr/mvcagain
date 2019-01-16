using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace mvcagain.Models
{
    public class BookstoreDb : IBookstoreDb
    {
        private string _connectionString = Properties.Settings.Default.connectionString;
        public string RunOnConnectionError { get; private set; }

        public IEnumerable<Publisher> GetPublishers()
        {
            IEnumerable<Publisher> publishers = null;
            RunOnConnection((dbCon) =>
            {
                publishers = dbCon.Query<Publisher>("select * from publishers");
            });
            return publishers;
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var dbcon = new SqlConnection(_connectionString))
            {
                //dbcon.Open();

                return dbcon.Query<Book>("select * from Books");
            }
        }

        public void Create(Book x)
        {
            RunOnConnection((dbCon) =>
            {
                dbCon.Query("INSERT INTO Books (Title, Author, Price, PublicationYear, PublisherId) VALUES (@Title,@Author, @Price,@PublicationYear,@PublisherId);",
                    new { Title = x.Title, Author = x.Author, Price = x.Price, PublicationYear = x.PublicationYear, PublisherId = x.PublisherId });
            });
        }
        public void Create(Publisher x)
        {
            RunOnConnection((dbCon) =>
            {
                dbCon.Query("INSERT INTO Publishers (Name) VALUES (@Name);",
                    new { Name = x.Name });
            });
        }


        public void Update(Book book)
        {

            RunOnConnection((dbCon) =>
            {
                dbCon.Query("UPDATE Books SET Title = @Title, Author=@Author, Price=@Price, PublicationYear = @PublicationYear, PublisherId = @PublisherId WHERE Id = @Id", new
                {
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear,
                    PublisherId = book.PublisherId
                });
            });

        }
        public void Update(Publisher publisher)
        {

            RunOnConnection((dbCon) =>
            {
                dbCon.Query("UPDATE Publishers SET Name = @Name WHERE Id = @Id",
                    new { Name = publisher.Name });
            });
        }

        public void DeleteBook(int? x)
        {
            RunOnConnection((dbCon) =>
            {
                dbCon.Query("DELETE FROM Books WHERE Id=@id",
                    new { id = x.GetValueOrDefault() });s
            });
        }

        public void DeletePublisher(int x)
        {
            RunOnConnection((dbCon) =>
            {
                dbCon.Query("DELETE FROM Publishers WHERE Id = @id",
                    new { id = x });
            });
        }

        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = null;

            RunOnConnection((dbCon) =>
            {
                books = dbCon.Query<Book>("select * from books");
            });

            return books;
        }

        public bool RunOnConnection(Action<SqlConnection> execute)
        {
            bool success = true;
            RunOnConnectionError = null;

            using (var dbcon = new SqlConnection(_connectionString))
            {
                try
                {
                    execute(dbcon);
                }
                catch (DbException e)
                {
                    RunOnConnectionError = e.Message;
                    success = false;
                }
            }
            return success;
        }
    }
}