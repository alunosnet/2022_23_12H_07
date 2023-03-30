using SkinsModulo17e.Data;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkinsModulo17e.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper,
            System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";

            using (var context = new SkinsModulo17eContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT utilizadorId FROM utilizadors WHERE email=@p0",
                    utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }

            return iduser;
        }
    }
}
