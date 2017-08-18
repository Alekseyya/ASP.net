namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        PhotoId = c.Int(nullable: true),
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
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrderPrice = c.Decimal(nullable: false, precision: 15, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 25),
                        IsDeleted = c.Boolean(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Descriptions = c.String(maxLength: 400),
                        Price = c.Decimal(nullable: false, precision: 15, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "ModificationId", "dbo.Modifications");
            DropForeignKey("dbo.Variants", "ItemId", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Modifications", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Models", "MarkId", "dbo.Marks");
            DropIndex("dbo.Variants", new[] { "ItemId" });
            DropIndex("dbo.Variants", new[] { "ModificationId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Users", new[] { "GroupId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Modifications", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "PhotoId" });
            DropIndex("dbo.Models", new[] { "MarkId" });
            DropTable("dbo.Variants");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Modifications");
            DropTable("dbo.Photos");
            DropTable("dbo.Models");
            DropTable("dbo.Marks");
            DropTable("dbo.Items");
            DropTable("dbo.Groups");
            DropTable("dbo.Categories");
        }
    }
}
