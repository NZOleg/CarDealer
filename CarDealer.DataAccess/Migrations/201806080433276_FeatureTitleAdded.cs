namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeatureTitleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarFeature", "Car_Feature", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarFeature", "Car_Feature");
        }
    }
}
