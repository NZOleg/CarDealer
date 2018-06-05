namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonLoginChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Username", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Person", "Password", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Employee", "Username");
            DropColumn("dbo.Employee", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Password", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employee", "Username", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Person", "Password");
            DropColumn("dbo.Person", "Username");
        }
    }
}
