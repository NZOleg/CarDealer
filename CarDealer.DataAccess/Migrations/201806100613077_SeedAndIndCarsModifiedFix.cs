namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAndIndCarsModifiedFix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IndividualCar", name: "CarModel_ModelID", newName: "Model_ID");
            RenameIndex(table: "dbo.IndividualCar", name: "IX_CarModel_ModelID", newName: "IX_Model_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.IndividualCar", name: "IX_Model_ID", newName: "IX_CarModel_ModelID");
            RenameColumn(table: "dbo.IndividualCar", name: "Model_ID", newName: "CarModel_ModelID");
        }
    }
}
