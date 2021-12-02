using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mboard.Models;
using Newtonsoft.Json;

namespace mboard.Controllers
{
    public class HomeController : Controller
    {
        private messageEntities db = new messageEntities();

        public ActionResult Index()
        {
            return View(db.Messageboard.ToList());
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

       
        public ActionResult Add()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,Parent_ID,comment,c_name,c_time")] Messageboard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Messageboard.Add(messageboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageboard);
        }


        public ActionResult Reply (string ID)
        {
            Session["ID"] = ID;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply([Bind(Include = "ID,Parent_ID,comment,c_name,c_time")] Messageboard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Messageboard.Add(messageboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageboard);
        }

        [HttpPost]
        public JsonResult Sort(string s_comment)
        {
            var query = from p in db.Messageboard
                        where p.comment == s_comment
                        select p;

            return Json(JsonConvert.SerializeObject(query));
        }
    }
}