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
    public class compraController : Controller
    {
        private SkinsModulo17eContext db = new SkinsModulo17eContext();

        // GET: compras
        public ActionResult Index()
        {

            var compras = db.compras.Include(c => c.utilizador).Include(s => s.skin);
            if (User.IsInRole("Administrador") == false)
            {
                int userid = db.utilizadors.Where(u => u.email == User.Identity.Name).First().utilizadorId;
                compras = db.compras.Where(u => u.utilizadorId == userid).Include(c => c.utilizador);

            }
            return View(compras.ToList());
        }

        // GET: compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: compras/Create
        public ActionResult Create()
        {
            ViewBag.UtilizadorId = new SelectList(db.utilizadors, "UtilizadorId", "nome");
            ViewBag.skinId = new SelectList(db.skins, "id", "nskin");
            ViewBag.preco = new SelectList(db.skins, "preco", "preco");
            if (User.IsInRole("Administrador") == false)
            {
                int userid = db.utilizadors.Where(u => u.email == User.Identity.Name).First().utilizadorId;
                ViewBag.UtilizadorId = new SelectList(db.utilizadors.Where(u=>u.utilizadorId==userid), "UtilizadorId", "nome");

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "compraId,data_aquisicao,preco,utilizadorId,skinId")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.skinId = new SelectList(db.skins, "id", "id", compra.skinId);
            ViewBag.utilizadorId = new SelectList(db.utilizadors, "utilizadorID", "nome", compra.utilizadorId);
            return View(compra);
        }

        // GET: compras/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.skinId = new SelectList(db.skins, "id", "id", compra.skinId);
            ViewBag.utilizadorId = new SelectList(db.utilizadors, "utilizadorID", "nome", compra.utilizadorId);
            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "compraId,data_aquisicao,preco,utilizadorId,skinId")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.skinId = new SelectList(db.skins, "id", "id", compra.skinId);
            ViewBag.utilizadorId = new SelectList(db.utilizadors, "utilizadorId", "nome", compra.utilizadorId);
            return View(compra);
        }

        // GET: compras/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: compras/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compra compra = db.compras.Find(id);
            db.compras.Remove(compra);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessaSaida(compra compra)
        {
            //atualiza a estadia
            db.Entry(compra).State = EntityState.Modified;

            //atualiza o quarto
            var skin = db.compras.Find(compra.skinId);
            db.Entry(skin).CurrentValues.SetValues(skin);
            db.SaveChanges();

            return RedirectToAction("ListaComprasEmCurso");
        }
    }
}
