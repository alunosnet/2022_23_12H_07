namespace SkinsModulo17e.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.compras",
                c => new
                    {
                        compraId = c.Int(nullable: false, identity: true),
                        data_aquisicao = c.DateTime(nullable: false),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        utilizadorId = c.Int(nullable: false),
                        skinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.compraId)
                .ForeignKey("dbo.skins", t => t.skinId, cascadeDelete: true)
                .ForeignKey("dbo.utilizadors", t => t.utilizadorId, cascadeDelete: true)
                .Index(t => t.utilizadorId)
                .Index(t => t.skinId);
            
            CreateTable(
                "dbo.skins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nSkin = c.String(nullable: false),
                        quantidade = c.Int(nullable: false),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.utilizadors",
                c => new
                    {
                        utilizadorID = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 80),
                        email = c.String(nullable: false),
                        nick = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.utilizadorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.compras", "utilizadorId", "dbo.utilizadors");
            DropForeignKey("dbo.compras", "skinId", "dbo.skins");
            DropIndex("dbo.compras", new[] { "skinId" });
            DropIndex("dbo.compras", new[] { "utilizadorId" });
            DropTable("dbo.utilizadors");
            DropTable("dbo.skins");
            DropTable("dbo.compras");
        }
    }
}
