namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarModelIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModel", "NumberOfSeats", c => c.Int(nullable: false));
            AlterColumn("dbo.CarModel", "EngineSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModel", "EngineSize", c => c.Int());
            AlterColumn("dbo.CarModel", "NumberOfSeats", c => c.Int());
        }
    }
}
