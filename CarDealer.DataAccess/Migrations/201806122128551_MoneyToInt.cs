namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoneyToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars_Sold", "Sale_Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars_Sold", "Sale_Price", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
