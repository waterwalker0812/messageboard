using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mboard.Models;

namespace mboard.Controllers
{
    public class MessageboardsController : Controller
    {
        private messageEntities db = new messageEntities();

        // GET: Messageboards
        public ActionResult Index()
        {
            return View(db.Messageboard.ToList());
        }

        // GET: Messageboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messageboard messageboard = db.Messageboard.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // GET: Messageboards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messageboards/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Parent_ID,comment,c_name,c_time")] Messageboard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Messageboard.Add(messageboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageboard);
        }

        // GET: Messageboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messageboard messageboard = db.Messageboard.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // POST: Messageboards/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Parent_ID,comment,c_name,c_time")] Messageboard messageboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageboard);
        }

        // GET: Messageboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messageboard messageboard = db.Messageboard.Find(id);
            if (messageboard == null)
            {
                return HttpNotFound();
            }
            return View(messageboard);
        }

        // POST: Messageboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messageboard messageboard = db.Messageboard.Find(id);
            db.Messageboard.Remove(messageboard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
