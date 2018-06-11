namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAndIndCarsModified : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IndividualCar", name: "Model_ID", newName: "CarModel_ModelID");
            RenameIndex(table: "dbo.IndividualCar", name: "IX_Model_ID", newName: "IX_CarModel_ModelID");
            AlterColumn("dbo.CarFeature", "Car_Feature_Description", c => c.String(maxLength: 256));
            AlterColumn("dbo.IndividualCar", "Current_Mileage", c => c.Int(nullable: false));
            AlterColumn("dbo.IndividualCar", "Date_Imported", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndividualCar", "Date_Imported", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.IndividualCar", "Current_Mileage", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CarFeature", "Car_Feature_Description", c => c.String(maxLength: 100));
            RenameIndex(table: "dbo.IndividualCar", name: "IX_CarModel_ModelID", newName: "IX_Model_ID");
            RenameColumn(table: "dbo.IndividualCar", name: "CarModel_ModelID", newName: "Model_ID");
        }
    }
}
