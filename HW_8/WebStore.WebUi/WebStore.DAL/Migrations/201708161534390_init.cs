namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BriefDescriptions = c.String(nullable: false),
                        Descriptions = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Show = c.Boolean(nullable: false),
                        Popular = c.Boolean(nullable: false),
                        Brand = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Main = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Years_Body = c.String(nullable: false),
                        Start = c.Int(nullable: false),
                        End = c.Int(nullable: false),
                        TecDoc = c.String(nullable: false),
                        PhotoId = c.Int(nullable: false),
                        Main = c.Boolean(nullable: false),
                        Market = c.Boolean(nullable: false),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marks", t => t.MarkId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.MarkId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        TypeSort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModificationId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        New = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Modifications", t => t.ModificationId, cascadeDelete: true)
                .Index(t => t.ModificationId)
                .Index(t => t.ItemId);
            
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Groups", "Name", c => c.String());
            AlterColumn("dbo.Orders", "OrderPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Descriptions", c => c.String());
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "ModificationId", "dbo.Modifications");
            DropForeignKey("dbo.Variants", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Modifications", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Models", "MarkId", "dbo.Marks");
            DropIndex("dbo.Variants", new[] { "ItemId" });
            DropIndex("dbo.Variants", new[] { "ModificationId" });
            DropIndex("dbo.Modifications", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "PhotoId" });
            DropIndex("dbo.Models", new[] { "MarkId" });
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 15, scale: 2));
            AlterColumn("dbo.Products", "Descriptions", c => c.String(maxLength: 400));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Orders", "OrderPrice", c => c.Decimal(nullable: false, precision: 15, scale: 2));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 250));
            DropTable("dbo.Variants");
            DropTable("dbo.Modifications");
            DropTable("dbo.Photos");
            DropTable("dbo.Models");
            DropTable("dbo.Marks");
            DropTable("dbo.Items");
        }
    }
}
