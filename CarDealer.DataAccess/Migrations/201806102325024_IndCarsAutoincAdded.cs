namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndCarsAutoincAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars_Sold", "Car_For_Sale_Id", "dbo.IndividualCar");
            DropForeignKey("dbo.FeaturesOnCars", "Car_For_Sale_ID", "dbo.IndividualCar");
            DropPrimaryKey("dbo.IndividualCar");
            AlterColumn("dbo.IndividualCar", "CarID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IndividualCar", "CarID");
            AddForeignKey("dbo.Cars_Sold", "Car_For_Sale_Id", "dbo.IndividualCar", "CarID");
            AddForeignKey("dbo.FeaturesOnCars", "Car_For_Sale_ID", "dbo.IndividualCar", "CarID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeaturesOnCars", "Car_For_Sale_ID", "dbo.IndividualCar");
            DropForeignKey("dbo.Cars_Sold", "Car_For_Sale_Id", "dbo.IndividualCar");
            DropPrimaryKey("dbo.IndividualCar");
            AlterColumn("dbo.IndividualCar", "CarID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IndividualCar", "CarID");
            AddForeignKey("dbo.FeaturesOnCars", "Car_For_Sale_ID", "dbo.IndividualCar", "CarID", cascadeDelete: true);
            AddForeignKey("dbo.Cars_Sold", "Car_For_Sale_Id", "dbo.IndividualCar", "CarID");
        }
    }
}
