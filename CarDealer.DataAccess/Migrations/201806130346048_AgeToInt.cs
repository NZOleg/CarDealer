namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Age", c => c.Double(nullable: false));
        }
    }
}
