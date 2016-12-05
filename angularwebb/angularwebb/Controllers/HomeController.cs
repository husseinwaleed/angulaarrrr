using angularwebb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angularwebb.Controllers
{
   
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Getdatalist()
        {
            var personlist = db.Persons.ToList();
            return Json(personlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getpersondetail(int? id)
        {
            var person = db.Persons.Where(p => p.Id == id).FirstOrDefault();

            return Json(person, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var person1 = db.Persons.Where(p => p.Id == id).FirstOrDefault();
            db.Persons.Remove(person1);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id, string firstname, string lastname, string country, string phone)
        {
             
           var person = db.Persons.Where(p => p.Id == id).FirstOrDefault();
            person.firstName = firstname;
            person.lastName = lastname;
            person.country = country;
            person.phone = phone;
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Create( string firstname, string lastname, string country, string phone)
        {

            Person person = new Person();
            person.firstName = firstname;
            person.lastName = lastname;
            person.country = country;
            person.phone = phone;
            db.Persons.Add(person);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}