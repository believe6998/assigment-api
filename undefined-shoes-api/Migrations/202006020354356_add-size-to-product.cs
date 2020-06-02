namespace undefined_shoes_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsizetoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Size", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Size");
        }
    }
}
