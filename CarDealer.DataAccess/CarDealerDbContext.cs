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
        public virtual DbSet<Cars_Sold> Cars_Sold { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<IndividualCar> IndividualCars { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarFeature>()
                .HasMany(e => e.IndividualCars)
                .WithMany(e => e.CarFeatures)
                .Map(m => m.ToTable("FeaturesOnCars").MapLeftKey("Car_Feature_ID").MapRightKey("Car_For_Sale_ID"));

            modelBuilder.Entity<CarModel>()
                .HasMany(e => e.IndividualCars)
                .WithRequired(e => e.CarModel)
                .HasForeignKey(e => e.Model_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cars_Sold>()
                .Property(e => e.Sale_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Cars_Sold)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IndividualCar>()
                .Property(e => e.Date_Imported)
                .IsFixedLength();

            modelBuilder.Entity<IndividualCar>()
                .HasMany(e => e.Cars_Sold)
                .WithRequired(e => e.IndividualCar)
                .HasForeignKey(e => e.Car_For_Sale_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Customer)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Employee)
                .WithRequired(e => e.Person);
        }
    }
}