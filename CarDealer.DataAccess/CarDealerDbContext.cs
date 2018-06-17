namespace CarDealer.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext()
            : base("name=CarDealerDbConnection")
        {
        }

        public virtual DbSet<CarFeature> CarFeatures { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarSale> Cars_Sold { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<IndividualCar> IndividualCars { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
