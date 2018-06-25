namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapStoredProcedures : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.CarFeature_Insert",
                p => new
                    {
                        Feature = p.String(maxLength: 50),
                        Description = p.String(maxLength: 256),
                    },
                body:
                    @"INSERT [dbo].[CarFeature]([Feature], [Description])
                      VALUES (@Feature, @Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[CarFeature]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[CarFeature] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.CarFeature_Update",
                p => new
                    {
                        Id = p.Int(),
                        Feature = p.String(maxLength: 50),
                        Description = p.String(maxLength: 256),
                    },
                body:
                    @"UPDATE [dbo].[CarFeature]
                      SET [Feature] = @Feature, [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.CarFeature_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CarFeature]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.CarModel_Insert",
                p => new
                    {
                        Model = p.String(maxLength: 50),
                        Manufacturer = p.String(maxLength: 50),
                        NumberOfSeats = p.Int(),
                        EngineSize = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[CarModel]([Model], [Manufacturer], [NumberOfSeats], [EngineSize])
                      VALUES (@Model, @Manufacturer, @NumberOfSeats, @EngineSize)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[CarModel]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[CarModel] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.CarModel_Update",
                p => new
                    {
                        Id = p.Int(),
                        Model = p.String(maxLength: 50),
                        Manufacturer = p.String(maxLength: 50),
                        NumberOfSeats = p.Int(),
                        EngineSize = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[CarModel]
                      SET [Model] = @Model, [Manufacturer] = @Manufacturer, [NumberOfSeats] = @NumberOfSeats, [EngineSize] = @EngineSize
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.CarModel_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CarModel]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.CarSale_Insert",
                p => new
                    {
                        SalePrice = p.Int(),
                        Date = p.DateTime(storeType: "date"),
                        Customer_Id = p.Int(),
                        IndividualCar_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[CarSale]([SalePrice], [Date], [Customer_Id], [IndividualCar_Id])
                      VALUES (@SalePrice, @Date, @Customer_Id, @IndividualCar_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[CarSale]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[CarSale] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.CarSale_Update",
                p => new
                    {
                        Id = p.Int(),
                        SalePrice = p.Int(),
                        Date = p.DateTime(storeType: "date"),
                        Customer_Id = p.Int(),
                        IndividualCar_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[CarSale]
                      SET [SalePrice] = @SalePrice, [Date] = @Date, [Customer_Id] = @Customer_Id, [IndividualCar_Id] = @IndividualCar_Id
                      WHERE ((([Id] = @Id) AND ([Customer_Id] = @Customer_Id)) AND ([IndividualCar_Id] = @IndividualCar_Id))"
            );
            
            CreateStoredProcedure(
                "dbo.CarSale_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Customer_Id = p.Int(),
                        IndividualCar_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CarSale]
                      WHERE ((([Id] = @Id) AND ([Customer_Id] = @Customer_Id)) AND ([IndividualCar_Id] = @IndividualCar_Id))"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Insert",
                p => new
                    {
                        Id = p.Int(),
                        LicenceNumber = p.String(maxLength: 30),
                        Age = p.Int(),
                        LicenseExpiryDate = p.DateTime(storeType: "date"),
                    },
                body:
                    @"INSERT [dbo].[Customer]([Id], [LicenceNumber], [Age], [LicenseExpiryDate])
                      VALUES (@Id, @LicenceNumber, @Age, @LicenseExpiryDate)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Update",
                p => new
                    {
                        Id = p.Int(),
                        LicenceNumber = p.String(maxLength: 30),
                        Age = p.Int(),
                        LicenseExpiryDate = p.DateTime(storeType: "date"),
                    },
                body:
                    @"UPDATE [dbo].[Customer]
                      SET [LicenceNumber] = @LicenceNumber, [Age] = @Age, [LicenseExpiryDate] = @LicenseExpiryDate
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Customer_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Customer]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Person_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Address = p.String(maxLength: 300),
                        Telephone = p.String(maxLength: 30),
                        Username = p.String(maxLength: 50),
                        Password = p.String(maxLength: 50),
                    },
                body:
                    @"INSERT [dbo].[Person]([Name], [Address], [Telephone], [Username], [Password])
                      VALUES (@Name, @Address, @Telephone, @Username, @Password)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Person]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Person_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50),
                        Address = p.String(maxLength: 300),
                        Telephone = p.String(maxLength: 30),
                        Username = p.String(maxLength: 50),
                        Password = p.String(maxLength: 50),
                    },
                body:
                    @"UPDATE [dbo].[Person]
                      SET [Name] = @Name, [Address] = @Address, [Telephone] = @Telephone, [Username] = @Username, [Password] = @Password
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Person_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Person]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Insert",
                p => new
                    {
                        Id = p.Int(),
                        OfficeAddress = p.String(maxLength: 300),
                        PhoneExtensionNumber = p.String(maxLength: 20),
                        Role = p.String(maxLength: 20),
                    },
                body:
                    @"INSERT [dbo].[Employee]([Id], [OfficeAddress], [PhoneExtensionNumber], [Role])
                      VALUES (@Id, @OfficeAddress, @PhoneExtensionNumber, @Role)"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Update",
                p => new
                    {
                        Id = p.Int(),
                        OfficeAddress = p.String(maxLength: 300),
                        PhoneExtensionNumber = p.String(maxLength: 20),
                        Role = p.String(maxLength: 20),
                    },
                body:
                    @"UPDATE [dbo].[Employee]
                      SET [OfficeAddress] = @OfficeAddress, [PhoneExtensionNumber] = @PhoneExtensionNumber, [Role] = @Role
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employee]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Employee_Delete");
            DropStoredProcedure("dbo.Employee_Update");
            DropStoredProcedure("dbo.Employee_Insert");
            DropStoredProcedure("dbo.Person_Delete");
            DropStoredProcedure("dbo.Person_Update");
            DropStoredProcedure("dbo.Person_Insert");
            DropStoredProcedure("dbo.Customer_Delete");
            DropStoredProcedure("dbo.Customer_Update");
            DropStoredProcedure("dbo.Customer_Insert");
            DropStoredProcedure("dbo.CarSale_Delete");
            DropStoredProcedure("dbo.CarSale_Update");
            DropStoredProcedure("dbo.CarSale_Insert");
            DropStoredProcedure("dbo.CarModel_Delete");
            DropStoredProcedure("dbo.CarModel_Update");
            DropStoredProcedure("dbo.CarModel_Insert");
            DropStoredProcedure("dbo.CarFeature_Delete");
            DropStoredProcedure("dbo.CarFeature_Update");
            DropStoredProcedure("dbo.CarFeature_Insert");
        }
    }
}
