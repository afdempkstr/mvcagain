using mvcagain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Delete(int? id)
        {
            var db = new BookstoreDb();
            var publishers = db.GetPublishers().Where(i => i.Id == id).FirstOrDefault();

            return View(publishers);
        }
        

    }
}