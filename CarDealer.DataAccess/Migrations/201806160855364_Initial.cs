namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarFeature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feature = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndividualCar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Colour = c.String(nullable: false, maxLength: 50),
                        CurrentMileage = c.Int(nullable: false),
                        DateImported = c.DateTime(nullable: false),
                        ManufactureYear = c.Int(),
                        Transmission = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                        BodyType = c.String(nullable: false, maxLength: 50),
                        AskingPrice = c.Int(nullable: false),
                        CarModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModel", t => t.CarModel_Id, cascadeDelete: true)
                .Index(t => t.CarModel_Id);
            
            CreateTable(
                "dbo.CarModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 50),
                        Manufacturer = c.String(nullable: false, maxLength: 50),
                        NumberOfSeats = c.Int(),
                        EngineSize = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarSale",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SalePrice = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.IndividualCar", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LicenceNumber = c.String(nullable: false, maxLength: 30),
                        Age = c.Int(nullable: false),
                        LicenseExpiryDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 300),
                        Telephone = c.String(maxLength: 30),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OfficeAddress = c.String(nullable: false, maxLength: 300),
                        PhoneExtensionNumber = c.String(nullable: false, maxLength: 20),
                        Role = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.IndividualCarCarFeatures",
                c => new
                    {
                        IndividualCar_Id = c.Int(nullable: false),
                        CarFeature_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IndividualCar_Id, t.CarFeature_Id })
                .ForeignKey("dbo.IndividualCar", t => t.IndividualCar_Id, cascadeDelete: true)
                .ForeignKey("dbo.CarFeature", t => t.CarFeature_Id, cascadeDelete: true)
                .Index(t => t.IndividualCar_Id)
                .Index(t => t.CarFeature_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarSale", "Id", "dbo.IndividualCar");
            DropForeignKey("dbo.CarSale", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Customer", "Id", "dbo.Person");
            DropForeignKey("dbo.Employee", "Id", "dbo.Person");
            DropForeignKey("dbo.IndividualCar", "CarModel_Id", "dbo.CarModel");
            DropForeignKey("dbo.IndividualCarCarFeatures", "CarFeature_Id", "dbo.CarFeature");
            DropForeignKey("dbo.IndividualCarCarFeatures", "IndividualCar_Id", "dbo.IndividualCar");
            DropIndex("dbo.IndividualCarCarFeatures", new[] { "CarFeature_Id" });
            DropIndex("dbo.IndividualCarCarFeatures", new[] { "IndividualCar_Id" });
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.Customer", new[] { "Id" });
            DropIndex("dbo.CarSale", new[] { "Customer_Id" });
            DropIndex("dbo.CarSale", new[] { "Id" });
            DropIndex("dbo.IndividualCar", new[] { "CarModel_Id" });
            DropTable("dbo.IndividualCarCarFeatures");
            DropTable("dbo.Employee");
            DropTable("dbo.Person");
            DropTable("dbo.Customer");
            DropTable("dbo.CarSale");
            DropTable("dbo.CarModel");
            DropTable("dbo.IndividualCar");
            DropTable("dbo.CarFeature");
        }
    }
}
