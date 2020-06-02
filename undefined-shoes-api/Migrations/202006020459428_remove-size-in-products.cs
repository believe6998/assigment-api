namespace undefined_shoes_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesizeinproducts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Size", c => c.Int(nullable: false));
        }
    }
}
