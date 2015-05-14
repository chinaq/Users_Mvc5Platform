namespace Users_Mvc5Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_My2City_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "My2City", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "MyCity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MyCity", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "My2City");
        }
    }
}
