using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenHammer.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> list = new List<string>()
        {
            "Pies", "Kot", "Krokodyl"
        };
        public ActionResult Index(string animalName = null)
        {
            if (animalName != null)
            {
                list.Add(animalName);
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.Message = "Ajax";
                return PartialView("ListPartial", list);
            }
            return View(list);
        }
        public ActionResult ListPartial()
        {
            ViewBag.Message = "Nie Ajax";
            return PartialView("ListPartial", list);
        }
        public ActionResult AddName(string animalName)
        {
            list.Add(animalName);
            return RedirectToAction("Index");
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