using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkinsModulo17e.Data;
using SkinsModulo17e.Models;

namespace SkinsModulo17e.Controllers
{
    [Authorize]
    public class skinsController : Controller
    {
        private SkinsModulo17eContext db = new SkinsModulo17eContext();

        // GET: skins
        public ActionResult Index()
        {
            return View(db.skins.ToList());
        }

        // GET: skins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skin skin = db.skins.Find(id);
            if (skin == null)
            {
                return HttpNotFound();
            }
            return View(skin);
        }

        // GET: skins/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "id,nSkin,quantidade,preco")] skin skin)
        {
            if (ModelState.IsValid)
            {
                db.skins.Add(skin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skin);
        }
        [Authorize(Roles ="Administrador")]

        // GET: skins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skin skin = db.skins.Find(id);
            if (skin == null)
            {
                return HttpNotFound();
            }
            return View(skin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]

        public ActionResult Edit([Bind(Include = "id,nSkin,quantidade,preco")] skin skin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skin);
        }

        // GET: skins/Delete/5

        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skin skin = db.skins.Find(id);
            if (skin == null)
            {
                return HttpNotFound();
            }
            return View(skin);
        }

        // POST: skins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skin skin = db.skins.Find(id);
            db.skins.Remove(skin);
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
