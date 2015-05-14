namespace Users_Mvc5Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_City_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MyCity", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "MyCity");
        }
    }
}
