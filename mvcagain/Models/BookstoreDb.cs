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

        public void Create(Book x)
        {
            string BookCreation = "INSERT INTO Books (Title, Author, Price, PublicationYear, PublisherId) VALUES (@Title,@Author, @Price,@PublicationYear,@PublisherId);";
            SqlConnection dbcon = new SqlConnection();

            using (dbcon)
            {
                var createBook = dbcon.Query(BookCreation, new { Title = x.Title, Author = x.Author, Price = x.Price, PublicationYear = x.PublicationYear, PublisherId = x.PublisherId });
            }
        }
        public void Create(Publisher x)
        {
            string publisherCreation = "INSERT INTO Publishers (Name) VALUES (@Name);";
            SqlConnection dbcon = new SqlConnection();

            using (dbcon)
            {
                var createPublisher = dbcon.Query(publisherCreation, new { Name = x.Name });
            }
        }


        public void Update(Book book)
        {
            string bookUpdate = "UPDATE Books SET Title = @Title, Author=@Author, Price=@Price, PublicationYear = @PublicationYear, PublisherId = @PublisherId WHERE Id = @Id";
            SqlConnection dbcon = new SqlConnection();

            using (dbcon)
            {
                var updateBook = dbcon.Query(bookUpdate, new
                {
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    PublicationYear = book.PublicationYear,
                    PublisherId = book.PublisherId
                });
            }


        }


        public void Update(Publisher publisher)
        {
            string publisherUpdate = "UPDATE Publishers SET Name = @Name WHERE Id = @Id";
            SqlConnection dbcon = new SqlConnection();

            using (dbcon)
            {
                var updatePublisher = dbcon.Query(publisherUpdate, new
                {
                    Name = publisher.Name
                });
            }
        }


        public void DeleteBook(int x)
        {
            string deletion = "DELETE FROM Books WHERE Id=@id";
            SqlConnection dbcon = new SqlConnection();

            using (dbcon)
            {
                var bookDeletion = dbcon.Query(deletion, new { id = x });
            }
        }


        public void DeletePublisher(int x)
        {
            string deletion = "DELETE FROM Publishers WHERE Id=@id";
            SqlConnection dbcon = new SqlConnection();

            using (dbcon)
            {
                var publisherDeletion = dbcon.Query(deletion, new { id = x });
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var dbcon = new SqlConnection(_connectionString))
            {

                return dbcon.Query<Book>("select * from books");
            }
            
        }
    }
}