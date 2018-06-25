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
                },
                new CarModel
                {
                    Manufacturer = "Nissan",
                    Model = "Lafesta",
                    NumberOfSeats = 7,
                    EngineSize = 2096
                },
                new CarModel
                {
                    Manufacturer = "Ford",
                    Model = "Ranger",
                    NumberOfSeats = 4,
                    EngineSize = 3199
                },
                new CarModel
                {
                    Manufacturer = "Toyota",
                    Model = "Land Cruiser Prado",
                    NumberOfSeats = 5,
                    EngineSize = 2982
                },
                new CarModel
                {
                    Manufacturer = "Subaru",
                    Model = "Forester",
                    NumberOfSeats = 5,
                    EngineSize = 1994
                },
                new CarModel
                {
                    Manufacturer = "Mazda",
                    Model = "3",
                    NumberOfSeats = 4,
                    EngineSize = 2260
                },
                new CarModel
                {
                    Manufacturer = "Nissan",
                    Model = "Teana",
                    NumberOfSeats = 5,
                    EngineSize = 2490
                }
                );
            context.SaveChanges();

            context.IndividualCars.AddOrUpdate(ic => ic.ImageUri,
                new IndividualCar
                {
                    Colour = "Grey",
                    CurrentMileage = 93830,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2008,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "Sedan",
                    AskingPrice = 5990,
                    ImageUri = "http://trademe.tmcdn.co.nz/photoserver/plus/814693817.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Nissan" && cm.Model == "Teana")
                },
                new IndividualCar
                {
                    Colour = "Black",
                    CurrentMileage = 134000,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2006,
                    Transmission = "Manual",
                    Status = "available",
                    BodyType = "Hatchback",
                    AskingPrice = 17995,
                    ImageUri = "http://trademe.tmcdn.co.nz/photoserver/full/814684291.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Mazda" && cm.Model == "3")
                },
                new IndividualCar
                {
                    Colour = "Silver",
                    CurrentMileage = 149100,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2005,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "RV/SUV",
                    AskingPrice = 6999,
                    ImageUri = "http://trademe.tmcdn.co.nz/photoserver/plusw/814653672.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Subaru" && cm.Model == "Forester")
                },
                new IndividualCar
                {
                    Colour = "Green",
                    CurrentMileage = 223000,
                    DateImported = DateTime.Today,
                    ManufactureYear = 1996,
                    Transmission = "Manual",
                    Status = "available",
                    BodyType = "RV/SUV",
                    AskingPrice = 12400,
                    ImageUri = "http://trademe.tmcdn.co.nz/photoserver/plusw/814649565.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Toyota" && cm.Model == "Land Cruiser Prado")
                },
                new IndividualCar
                {
                    Colour = "White",
                    CurrentMileage = 185346,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2009,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "Ute",
                    AskingPrice = 25650,
                    ImageUri = "http://i.ebayimg.com/00/s/NDgwWDY0MA==/z/O7oAAOSw0A9axwgp/$_20.JPG?set_id=2",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Ford" && cm.Model == "Ranger")
                },
                new IndividualCar
                {
                    Colour = "Grey",
                    CurrentMileage = 132400,
                    DateImported = DateTime.Today,
                    ManufactureYear = 2005,
                    Transmission = "Automatic",
                    Status = "available",
                    BodyType = "Station Wagon",
                    AskingPrice = 4300,
                    ImageUri = "http://cdn-www.cardealpage.com/carimage/17151962/03.jpg",
                    CarModel = context.CarModels.Single(cm => cm.Manufacturer == "Nissan" && cm.Model == "Lafesta")
                },
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
                    Telephone = "+0123456789",
                    Username = "q",
                    Password = "q"
                },
                new Person
                {
                    Name = "Mark",
                    Address = "Wellington",
                    Telephone = "+1011121314",
                    Username = "Mark",
                    Password = "Mark"
                },
                new Person
                {
                    Name = "Aman",
                    Address = "Hamilton",
                    Telephone = "+1516171819",
                    Username = "Aman",
                    Password = "Aman"
                },
                new Person
                {
                    Name = "Steven",
                    Address = "Bejine",
                    Telephone = "+2021222324",
                    Username = "Steven",
                    Password = "Steven"
                },
                new Person
                {
                    Name = "admin",
                    Address = "9/17 Byron Ave, Takapuna, Auckland 0622",
                    Telephone = "+2021222324",
                    Username = "admin",
                    Password = "admin"
                },
                new Person
                {
                    Name = "staff",
                    Address = "3 Akoranga Dr, Northcote, Auckland 0741",
                    Telephone = "+2021222324",
                    Username = "staff",
                    Password = "staff"
                },
                new Person
                {
                    Name = "customer",
                    Address = "3/170 Wairau Road, Glenfield, Auckland 0627",
                    Telephone = "+2021222324",
                    Username = "customer",
                    Password = "customer"
                }
                );
            context.SaveChanges();
            context.Employees.AddOrUpdate(e => e.OfficeAddress, //doesn't let me to use Person as a matching param
                new Employee
                {
                    OfficeAddress = "MIT",
                    PhoneExtensionNumber = "+123",
                    Role = "admin",
                    Person = context.People.Single(p => p.Username == "q")
                },
                new Employee
                {
                    OfficeAddress = "19 Lakewood Ct, Manukau, Auckland 2104",
                    PhoneExtensionNumber = "+123",
                    Role = "admin",
                    Person = context.People.Single(p => p.Username == "Mark")
                },
                new Employee
                {
                    OfficeAddress = "156 Chapel Rd, Flat Bush, Auckland 2016",
                    PhoneExtensionNumber = "+123",
                    Role = "staff",
                    Person = context.People.Single(p => p.Username == "Aman")
                },
                new Employee
                {
                    OfficeAddress = "9/17 Byron Ave, Takapuna, Auckland 0622",
                    PhoneExtensionNumber = "+123",
                    Role = "admin",
                    Person = context.People.Single(p => p.Username == "admin")
                },
                new Employee
                {
                    OfficeAddress = "3 Akoranga Dr, Northcote, Auckland 0741",
                    PhoneExtensionNumber = "+123",
                    Role = "staff",
                    Person = context.People.Single(p => p.Username == "staff")
                }
                );
            context.Customers.AddOrUpdate(e => e.LicenceNumber,
                new Customer
                {
                    Age = 23,
                    LicenceNumber = "fdasfnj23132",
                    LicenseExpiryDate = DateTime.Today,
                    Person = context.People.Single(p => p.Username == "Steven")
                },
                new Customer
                {
                    Age = 51,
                    LicenceNumber = "dsafsad32521",
                    LicenseExpiryDate = DateTime.Today,
                    Person = context.People.Single(p => p.Username == "customer")
                }
                );

            context.SaveChanges();
        }
    }
}
