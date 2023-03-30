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
    [Authorize(Roles ="Administrador")]
    public class utilizadorsController : Controller
    {
        private SkinsModulo17eContext db = new SkinsModulo17eContext();

        // GET: utilizadors
        public ActionResult Index()
        {
            return View(db.utilizadors.ToList());
        }

        // GET: utilizadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilizador utilizador = db.utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // GET: utilizadors/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "utilizadorId,nome,email,nick,Password")] utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        // GET: utilizadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilizador utilizador = db.utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "utilizadorId,nome,email,nick,Password")] utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                utilizador utilizador2 = db.utilizadors.Find(utilizador.utilizadorId);
                utilizador2.nick = utilizador.nick;
                utilizador2.nome = utilizador.nome;
                db.Entry(utilizador2).CurrentValues.SetValues(utilizador2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilizador);
        }
        [Authorize(Roles = "Administrador")]
        // GET: utilizadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilizador utilizador = db.utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }
        [Authorize(Roles = "Administrador")]
        // POST: utilizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            utilizador utilizador = db.utilizadors.Find(id);
            db.utilizadors.Remove(utilizador);
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
