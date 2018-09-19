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

                if (!context.Collectible.Any ()) {

                    context.Manufacturer.AddRange (
                        new Manufacturer {
                            Name = "Dell",
                            Model = 2018
                        },

                        new Manufacturer {
                            Name = "HP",
                            Model = 2018
                        },
                        new Manufacturer {
                            Name = "Lenovo",
                            Model = 2018
                        },
                        new Manufacturer {
                            Name = "Asus",
                            Model = 2018
                        });
            }
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
                },

                new Collectible {
                    Name = "Dell E070",
                        DateOfPurchase = DateTime.Parse ("2016-6-15"),
                        Category = "Electronics",
                        Price = 700.00M,
                        ManufacturerID = 1
                },

                new Collectible {
                    Name = "Dell E080",
                        DateOfPurchase = DateTime.Parse ("2018-4-18"),
                        Category = "Electronics",
                        Price = 800.00M,
                        ManufacturerID = 1
                },

                new Collectible {
                    Name = "Dell E090",
                        DateOfPurchase = DateTime.Parse ("2018-2-18"),
                        Category = "Electronics",
                        Price = 900.00M,
                        ManufacturerID = 1
                },

                new Collectible {
                    Name = "HP Spectre",
                        DateOfPurchase = DateTime.Parse ("2018-6-08"),
                        Category = "Electronics",
                        Price = 900.00M,
                        ManufacturerID = 2
                },

                new Collectible {
                    Name = "HP Spectre x360",
                        DateOfPurchase = DateTime.Parse ("2018-9-18"),
                        Category = "Electronics",
                        Price = 1200.00M,
                        ManufacturerID = 2
                },

                new Collectible {
                    Name = "HP Elitebook",
                        DateOfPurchase = DateTime.Parse ("2017-03-11"),
                        Category = "Electronics",
                        Price = 700.00M,
                        ManufacturerID = 2
                },

                new Collectible {
                    Name = "HP Elitebook E800",
                        DateOfPurchase = DateTime.Parse ("2018-02-11"),
                        Category = "Electronics",
                        Price = 800.00M,
                        ManufacturerID = 2
                },

                new Collectible {
                    Name = "HP Elitebook x2",
                        DateOfPurchase = DateTime.Parse ("2018-04-11"),
                        Category = "Electronics",
                        Price = 1400.00M,
                        ManufacturerID = 2
                },

                new Collectible {
                    Name = "HP Elitebook E850",
                        DateOfPurchase = DateTime.Parse ("2018-09-11"),
                        Category = "Electronics",
                        Price = 800.00M,
                        ManufacturerID = 2
                }

            );

            context.SaveChanges ();

        }
    }
}
}