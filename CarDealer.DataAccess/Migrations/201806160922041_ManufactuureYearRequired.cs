namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufactuureYearRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndividualCar", "ManufactureYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndividualCar", "ManufactureYear", c => c.Int());
        }
    }
}
