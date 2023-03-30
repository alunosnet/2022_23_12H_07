using SkinsModulo17e.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkinsModulo17e.Controllers
{
    public class ConsultasController : Controller
    {
        private SkinsModulo17eContext db = new SkinsModulo17eContext();

        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult PesquisaCliente()
        {
            string nome = Request.Form["tbNome"];
            var clientes = db.utilizadors.Where(c => c.nome.Contains(nome));
            return View("PesquisaCliente", clientes.ToList());
        }
        public ActionResult PesquisaDinamica()
        {
            return View();
        }
        public JsonResult PesquisaNome(string nome)
        {
            var clientes = db.utilizadors.Where(c => c.nome.Contains(nome)).ToList();
            var lista = new List<Campos>();
            foreach (var c in clientes)
                lista.Add(new Campos() { nome = c.nome });
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MelhorCliente()
        {
            string sql = @"SELECT nome,sum(preco) as valor
                            FROM compras INNER JOIN utilizadors
                            ON compras.utilizadorId=utilizadors.utilizadorId
                            GROUP BY compras.utilizadorId,nome
                            ORDER BY valor DESC";

            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }
        public ActionResult CompraDeUmCliente()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CompraDeUmCliente(string nome)
        {
            string sql = @"Select nome,count(*) as n_compras
                            from compras INNER JOIN utilizadors
                            ON compras.utilizadorId=utilizadors.utilizadorId
                            where nome like @p0
                            GROUP By nome";

            // SqlParameter parametro = new SqlParameter("@p1", "%" + nome + "%");
            var compras = db.Database.SqlQuery<Campos>(sql, "%" + nome + "%");

            if (compras != null && compras.ToList().Count > 0)
                ViewBag.compras = compras.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.compras = temp;
            }
            return View();
        }
        public class Campos
        {
            public string nome { get; set; }
            public decimal valor { get; set; }
            public int n_compras { get; set; }
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
