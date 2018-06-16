namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AskingPriceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualCar", "AskingPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualCar", "AskingPrice");
        }
    }
}
