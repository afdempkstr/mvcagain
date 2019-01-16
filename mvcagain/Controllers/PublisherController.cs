using mvcagain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mvcagain.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        // GET: Publisher
        public ActionResult Index()
        {
            var db = new BookstoreDb();

            var publishers = db.GetPublishers();

            return View(publishers.ToList());
        }

        public ActionResult Create()
        {
            var db = new BookstoreDb();
                       
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="Name")]Publisher publisher)
        {
            if (string.IsNullOrWhiteSpace(publisher.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new BookstoreDb();
            db.Create(publisher);
            if (!string.IsNullOrWhiteSpace(db.RunOnConnectionError))
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db = new BookstoreDb();
            var publisher = db.GetPublishers().Where(i => i.Id == id).FirstOrDefault();

            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var db = new BookstoreDb();
            db.DeletePublisher(id);
            
            return RedirectToAction("Index");
        }

    }
}