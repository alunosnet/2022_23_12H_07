namespace SkinsModulo17e.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catalisador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.utilizadors", "Password", c => c.String(nullable: false));
            AddColumn("dbo.utilizadors", "Perfil", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.utilizadors", "Perfil");
            DropColumn("dbo.utilizadors", "Password");
        }
    }
}
