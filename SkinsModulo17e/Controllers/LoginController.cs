using SkinsModulo17e.Data;
using SkinsModulo17e.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SkinsModulo17e.Controllers
{
    public class LoginController : Controller
    {
        private SkinsModulo17eContext db = new SkinsModulo17eContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(utilizador utilizador)
        {
            if (utilizador.email != null && utilizador.Password != null)
            {
                ////hash password
                //HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                //var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                //utilizador.Password = Convert.ToBase64String(password);
                foreach (var u in db.utilizadors.ToList())
                {
                    if (u.email.ToLower() == utilizador.email.ToLower() && u.Password==utilizador.Password)
                    {
                        //iniciar sessão
                        FormsAuthentication.SetAuthCookie(utilizador.email, false);
                        //redirecionar
                        if (Request.QueryString["ReturnUrl"] == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente novamente.");
            return View(utilizador);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}