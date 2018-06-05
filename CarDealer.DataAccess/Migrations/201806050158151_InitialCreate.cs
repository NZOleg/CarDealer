namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarFeature",
                c => new
                    {
                        FeatureID = c.Int(nullable: false, identity: true),
                        Car_Feature_Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.FeatureID);
            
            CreateTable(
                "dbo.IndividualCar",
                c => new
                    {
                        CarID = c.Int(nullable: false),
                        Colour = c.String(nullable: false, maxLength: 50),
                        Current_Mileage = c.String(nullable: false, maxLength: 50),
                        Date_Imported = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Manufacture_Year = c.Int(nullable: false),
                        Transmission = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                        Body_Type = c.String(nullable: false, maxLength: 50),
                        Model_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.CarModel", t => t.Model_ID)
                .Index(t => t.Model_ID);
            
            CreateTable(
                "dbo.CarModel",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 50),
                        Manufacturer = c.String(nullable: false, maxLength: 50),
                        NumberOfSeats = c.Int(nullable: false),
                        EngineSize = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID);
            
            CreateTable(
                "dbo.Cars_Sold",
                c => new
                    {
                        Car_Sold_ID = c.Int(nullable: false, identity: true),
                        Car_For_Sale_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Sale_Price = c.Decimal(nullable: false, storeType: "money"),
                        Date_Sold = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Car_Sold_ID)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .ForeignKey("dbo.IndividualCar", t => t.Car_For_Sale_Id)
                .Index(t => t.Car_For_Sale_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        Licence_Number = c.String(nullable: false, maxLength: 30),
                        Age = c.Double(nullable: false),
                        License_Expiry_Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Person", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 300),
                        Telephone = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        Office_Address = c.String(nullable: false, maxLength: 300),
                        Phone_Extension_Number = c.String(nullable: false, maxLength: 20),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Role = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Person", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.FeaturesOnCars",
                c => new
                    {
                        Car_Feature_ID = c.Int(nullable: false),
                        Car_For_Sale_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Car_Feature_ID, t.Car_For_Sale_ID })
                .ForeignKey("dbo.CarFeature", t => t.Car_Feature_ID, cascadeDelete: true)
                .ForeignKey("dbo.IndividualCar", t => t.Car_For_Sale_ID, cascadeDelete: true)
                .Index(t => t.Car_Feature_ID)
                .Index(t => t.Car_For_Sale_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeaturesOnCars", "Car_For_Sale_ID", "dbo.IndividualCar");
            DropForeignKey("dbo.FeaturesOnCars", "Car_Feature_ID", "dbo.CarFeature");
            DropForeignKey("dbo.Cars_Sold", "Car_For_Sale_Id", "dbo.IndividualCar");
            DropForeignKey("dbo.Employee", "EmployeeID", "dbo.Person");
            DropForeignKey("dbo.Customer", "CustomerID", "dbo.Person");
            DropForeignKey("dbo.Cars_Sold", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.IndividualCar", "Model_ID", "dbo.CarModel");
            DropIndex("dbo.FeaturesOnCars", new[] { "Car_For_Sale_ID" });
            DropIndex("dbo.FeaturesOnCars", new[] { "Car_Feature_ID" });
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropIndex("dbo.Customer", new[] { "CustomerID" });
            DropIndex("dbo.Cars_Sold", new[] { "Customer_Id" });
            DropIndex("dbo.Cars_Sold", new[] { "Car_For_Sale_Id" });
            DropIndex("dbo.IndividualCar", new[] { "Model_ID" });
            DropTable("dbo.FeaturesOnCars");
            DropTable("dbo.Employee");
            DropTable("dbo.Person");
            DropTable("dbo.Customer");
            DropTable("dbo.Cars_Sold");
            DropTable("dbo.CarModel");
            DropTable("dbo.IndividualCar");
            DropTable("dbo.CarFeature");
        }
    }
}
