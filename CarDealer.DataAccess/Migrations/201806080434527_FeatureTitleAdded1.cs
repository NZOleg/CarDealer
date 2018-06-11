namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeatureTitleAdded1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarFeature", "Car_Feature_Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarFeature", "Car_Feature_Description", c => c.String(maxLength: 50));
        }
    }
}
