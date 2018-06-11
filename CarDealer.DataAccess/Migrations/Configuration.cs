namespace CarDealer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealer.DataAccess.CarDealerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealer.DataAccess.CarDealerDbContext context)
        {
            context.CarFeatures.AddOrUpdate(cf => cf.Car_Feature,
                new CarFeature { Car_Feature = "Cruise Control", Car_Feature_Description = "It is a system that automatically controls the speed of a motor vehicle." },
                new CarFeature { Car_Feature = "4WD", Car_Feature_Description = "Four wheel drive (4WD) refers to vehicles with two axles providing torque to four wheel ends." },
                new CarFeature { Car_Feature = "Seat Heater", Car_Feature_Description = "This seat heater is designed to warm your seats on SUVs, RVs, trucks or any other vehicles. " },
                new CarFeature { Car_Feature = "Tow Hitch", Car_Feature_Description = "A tow hitch (or tow bar) is a device attached to the chassis of a vehicle for towing, or a towbar to an aircraft nose gear." },
                new CarFeature { Car_Feature = "Automatic transmission", Car_Feature_Description = "it is a type of motor vehicle transmission that can automatically change gear ratios as the vehicle moves, freeing the driver from having to shift gears manually." },
                new CarFeature { Car_Feature = "DVD Video System", Car_Feature_Description = "From in-dash DVD players to easy-add-on portable systems, car video makes your trips a lot more fun, and this article covers the topic from front to back." },
                new CarFeature { Car_Feature = "Third Row Seat", Car_Feature_Description = "Third row seating refers to seating in a vehicle such as a station wagon, SUV, MPV, or minivan to expand seating beyond the front and back seat found in most automobiles." },
                new CarFeature { Car_Feature = "Sunroof", Car_Feature_Description = "An automotive sunroof is a movable (typically glass) panel that is operable to uncover an opening in an automobile roof, which allows light and/or fresh air to enter the passenger compartment." },
                new CarFeature { Car_Feature = "Navigation System", Car_Feature_Description = "An automotive navigation system is part of the automobile controls or a third party add-on used to find direction in an automobile." },
                new CarFeature { Car_Feature = "Leather Seats", Car_Feature_Description = "For decades, one's ability to utter the phrase It has leather seats was a defining factor in whether or not other people thought your car was nice." }
                );

            context.CarModels.AddOrUpdate(cm => cm.ModelID,
                new CarModel { ModelID = 1,  Model = "Sonata", Manufacturer= "Hyundai", EngineSize= 2.4, NumberOfSeats=5 },
                new CarModel { ModelID = 2, Model = "Ford", Manufacturer= "Focus", EngineSize= 2.0, NumberOfSeats=5 },
                new CarModel { ModelID = 3, Model = "Chevrolet", Manufacturer= "Cruze", EngineSize= 1.4, NumberOfSeats=5 },
                new CarModel { ModelID = 4, Model = "Hyundai", Manufacturer= "Hyundai", EngineSize= 1.6, NumberOfSeats=5 },
                new CarModel { ModelID = 5, Model = "Ford", Manufacturer= "Fusion", EngineSize= 2.5, NumberOfSeats=5 },
                new CarModel { ModelID = 6, Model = "Honda", Manufacturer= "Civic", EngineSize= 2.0, NumberOfSeats=5 },
                new CarModel { ModelID = 7, Model = "Nissan", Manufacturer= "Altima", EngineSize= 2.5, NumberOfSeats=5 },
                new CarModel { ModelID = 8, Model = "Honda", Manufacturer= "Accord", EngineSize= 2.4, NumberOfSeats=5 },
                new CarModel { ModelID = 9, Model = "Toyota", Manufacturer= "Corolla", EngineSize= 1.8, NumberOfSeats=5 },
                new CarModel { ModelID = 10, Model = "Toyota", Manufacturer= "Camry", EngineSize= 2.4, NumberOfSeats=5 }
                );
            context.SaveChanges();
            context.IndividualCars.AddOrUpdate(ic => ic.CarID,
                new IndividualCar { CarID = 1, Colour="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 2, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 3, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 4, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 5, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 6, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 7, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 8, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 9, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") },
                new IndividualCar { CarID = 10, Colour ="black", Current_Mileage=150000, Date_Imported=new DateTime(2001,1,1), Manufacture_Year=2005, Transmission="auto", Status="available", Body_Type="sedan", CarModel = context.CarModels.Single(cm => cm.Model == "Nissan") }
                );
        }
    }
}
