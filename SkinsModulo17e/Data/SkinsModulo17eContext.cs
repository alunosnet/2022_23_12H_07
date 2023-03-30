using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkinsModulo17e.Data
{
    public class SkinsModulo17eContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SkinsModulo17eContext() : base("name=SkinsModulo17eContext")
        {
        }

        public System.Data.Entity.DbSet<SkinsModulo17e.Models.compra> compras { get; set; }

        public System.Data.Entity.DbSet<SkinsModulo17e.Models.skin> skins { get; set; }

        public System.Data.Entity.DbSet<SkinsModulo17e.Models.utilizador> utilizadors { get; set; }
    }
}
