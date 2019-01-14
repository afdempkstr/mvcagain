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
        public ActionResult Index()
        {
            var db = new BookstoreDb();

            var publishers = db.GetPublishers();

            ViewBag.PageTitle = "Publisher list";

            return View(publishers.ToList());
        }

        public ActionResult Test()
        {
            var model = new Publisher();

            var validator = new PublisherValidator();
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                //do action
            }
            else
            {
                var message = validationResult.Errors.First().ErrorMessage;
            }

            return new HttpStatusCodeResult(200);
        }
    }
}