namespace Globalmantics.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItem", "CatalogItemId", "dbo.CatalogItem");
            AlterColumn("dbo.CatalogItem", "Description", c => c.String(nullable: false, maxLength: 100));
            AddForeignKey("dbo.CartItem", "CatalogItemId", "dbo.CatalogItem", "CatalogItemId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "CatalogItemId", "dbo.CatalogItem");
            AlterColumn("dbo.CatalogItem", "Description", c => c.String());
            AddForeignKey("dbo.CartItem", "CatalogItemId", "dbo.CatalogItem", "CatalogItemId", cascadeDelete: true);
        }
    }
}
