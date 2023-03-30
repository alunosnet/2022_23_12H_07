namespace SkinsModulo17e.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catalizador : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.utilizadors", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.utilizadors", "Password", c => c.String(nullable: false));
        }
    }
}
