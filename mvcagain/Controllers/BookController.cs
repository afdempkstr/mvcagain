using mvcagain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcagain.Models;


namespace mvcagain.Controllers
{
    public class BookController : Controller
    {
        private BookstoreDb _db = new BookstoreDb();

        // GET: Book
        public ActionResult Index()
        {
            var db = new BookstoreDb();

            var books = db.GetBooks();

            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var publishers = _db.GetPublishers();

            var list = new SelectList(publishers, "Id", "Name");
            
            return View(list);
        }

        // POST: Book/Create
        [HttpPost]
        public string Create(Book book)
        {
            var db = new BookstoreDb();

            db.Create(book);

            return db.RunOnConnectionError ?? "Book was Created !!!";

        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            var db = new BookstoreDb();

            db.DeleteBook(id.GetValueOrDefault());

            var books = db.GetBooks().Where(i => i.Id == id).FirstOrDefault();

            return View(books);
          
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
