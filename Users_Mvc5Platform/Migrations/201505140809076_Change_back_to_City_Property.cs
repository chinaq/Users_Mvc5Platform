namespace Users_Mvc5Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_back_to_City_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "My4City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "My4City", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
