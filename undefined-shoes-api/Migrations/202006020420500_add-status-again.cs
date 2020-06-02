namespace undefined_shoes_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatusagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Status", c => c.Int(nullable: false));
        }
    }
}
