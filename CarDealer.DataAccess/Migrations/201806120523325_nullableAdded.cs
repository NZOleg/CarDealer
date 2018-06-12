namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndividualCar", "Manufacture_Year", c => c.Int());
            AlterColumn("dbo.CarModel", "NumberOfSeats", c => c.Int());
            AlterColumn("dbo.CarModel", "EngineSize", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModel", "EngineSize", c => c.Double(nullable: false));
            AlterColumn("dbo.CarModel", "NumberOfSeats", c => c.Int(nullable: false));
            AlterColumn("dbo.IndividualCar", "Manufacture_Year", c => c.Int(nullable: false));
        }
    }
}
