namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUriAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualCar", "ImageUri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualCar", "ImageUri");
        }
    }
}
