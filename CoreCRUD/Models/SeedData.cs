using System;
using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCRUD.Models {
        public static class SeedData {
            public static void Initialize (IServiceProvider serviceProvider) {
                using (var context = new AppDbContext (
                    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>> ())) {

                    if (context.Collectible.Any ()) {
                        return; // DB has been seeded
                    }
                    var faker = new Faker ();
                    context.Collectible.AddRange (
                        new Collectible {
                            Name = "Lenovo Yoga 720",
                                DateOfPurchase = DateTime.Parse ("2016-5-25"),
                                Category = "Electronics",
                                Price = 700.00M,
                                ManufacturerID = 3
                        },

                        new Collectible {
                            Name = "Lenovo Yoga 730",
                                DateOfPurchase = DateTime.Parse ("2018-2-12"),
                                Category = "Electronics",
                                Price = 800.00M,
                                ManufacturerID = 3
                        }

                    );

                    // context.Manufacturer.AddRange (
                    //     new Manufacturer {
                    //         Name = faker.Person.Company.Name,
                    //             Model = DateTime.Parse ("2016-5-25"),
                    //             Category = "Electronics",
                    //             Price = 700.00M,
                    //             ManufacturerID = 3
                    //     },

                    //     new Manufacturer {
                    //         Name = faker.Person.Company.Name,
                    //             DateOfPurchase = DateTime.Parse ("2018-2-12"),
                    //             Category = "Electronics",
                    //             Price = 800.00M,
                    //             ManufacturerID = 3
                    //     });
                        context.SaveChanges ();

                    }
                }
            }
        }