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
            context.CarFeatures.AddOrUpdate(cf => cf.Feature,
                new CarFeature
                {
                    Feature = "Anti-Lock Brakes",
                    Description = "Cars with anti-lock brakes are much safer. When you have to slam on the brakes to avoid an accident, you do not want the brakes locking up."
                },
                new CarFeature
                {
                    Feature = "Airbags",
                    Description = "Airbags help to greatly reduce the threat of injury when in a collision."
                },
                              new CarFeature
                              {
                                  Feature = "Rear Camera/Sensors",
                                  Description = "The rearview camera allows you to see behind the vehicle without having to maneuver using mirrors."
                              },
                              new CarFeature
                              {
                                  Feature = "4-Wheel Drive",
                                  Description = "For driving in bad weather, having four-wheel drive capability is much safer and will ensure that you can navigate through snow and poor road conditions."
                              },
                              new CarFeature
                              {
                                  Feature = "Third Row Seating",
                                  Description = "As families grow, your vehicle needs more space. Third row seating allows everyone to be comfortable while traveling."
                              },
                              new CarFeature
                              {
                                  Feature = "Rear Seat Entertainment",
                                  Description = "Having the DVD system for the children while they ride in the back seats makes traveling anywhere much easier. "
                              },
                              new CarFeature
                              {
                                  Feature = "Infotainment System",
                                  Description = "Rear seat entertainment is great, but how about for the entire vehicle? A great infotainment system will include things like iPod hookups and more."
                              },
                              new CarFeature
                              {
                                  Feature = "Programmable Keys",
                                  Description = "Only those with the correct key will be able to start your vehicle. This is a great feature if there happens to be a teen driver in the household."
                              }
                              );
            context.SaveChanges();

            context.CarModels.AddOrUpdate(cm => cm.Model,
                new CarModel
                {
                    Manufacturer = "BMW",
                    Model = "X6",
                    NumberOfSeats = 5,
                    EngineSize = 4395
                },
                new CarModel
                {
                    Manufacturer = "Subaru",
                    Model = "Legacy",
                    NumberOfSeats = 4,
                    EngineSize = 1994
                },
                new CarModel
                {
                    Manufacturer = "BMW",
                    Model = "335i",
                    NumberOfSeats = 5,
                    EngineSize = 2979
                }
                );
            context.SaveChanges();

            context.IndividualCars.AddOrUpdate(ic => ic.ImageUri,
                new IndividualCar
                {
                    Colour = "Black",
                    CurrentMileage = 124062,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2013,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "RV/SUV",
                    AskingPrice = 59000,
                    ImageUri = "http://reviews.everycarlisted.com/images/14rwyi101_medium.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "BMW" && cm.Model == "X6")
                },
                new IndividualCar
                {
                    Colour = "White",
                    CurrentMileage = 165200,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2006,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "Station Wagon",
                    AskingPrice = 9200,
                    ImageUri = "http://www.cars-directory.net/pics/subaru/legacy_b4/2006/subaru_legacy_b4_a1236483610b2526207.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Subaru" && cm.Model == "Legacy")
                },
                new IndividualCar
                {
                    Colour = "Black",
                    CurrentMileage = 85000,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2013,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "Sedan",
                    AskingPrice = 35000,
                    ImageUri = "http://i42.tinypic.com/1q3ac6.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "BMW" && cm.Model == "335i")
                }


                );
            context.People.AddOrUpdate(p => p.Username,
                new Person
                {
                    Name = "Oleg",
                    Address = "Auckland",
                    Telephone = "+123456789",
                    Username = "q",
                    Password = "q"
                });
            context.SaveChanges();
            context.Employees.AddOrUpdate(e => e.OfficeAddress, //doesn't let me to use Person as a matching param
                new Employee
                {
                    OfficeAddress = "MIT",
                    PhoneExtensionNumber = "+123",
                    Role = "admin",
                    Person = context.People.Single(p => p.Username == "q")
                });
        }

    }
}
