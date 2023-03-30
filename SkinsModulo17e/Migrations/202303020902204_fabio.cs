namespace SkinsModulo17e.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fabio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.compras", "utilizadorId", "dbo.utilizadors");
            DropPrimaryKey("dbo.utilizadors");
            DropColumn("dbo.utilizadors", "ClienteID");
            AddColumn("dbo.utilizadors", "utilizadorId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.utilizadors", "utilizadorId");
            AddForeignKey("dbo.compras", "utilizadorId", "dbo.utilizadors", "utilizadorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.utilizadors", "ClienteID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.compras", "utilizadorId", "dbo.utilizadors");
            DropPrimaryKey("dbo.utilizadors");
            DropColumn("dbo.utilizadors", "utilizadorId");
            AddPrimaryKey("dbo.utilizadors", "ClienteID");
            AddForeignKey("dbo.compras", "utilizadorId", "dbo.utilizadors", "ClienteID", cascadeDelete: true);
        }
    }
}
