using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop1.Models;

namespace Shop1.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //// CATEGORIES
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            CategoryName = "sets" //1
                        },

                        new Category()
                        {
                            CategoryName = "face oils" //2
                        },

                        new Category()
                        {
                            CategoryName = "moisturizers" //3
                        },

                        new Category()
                        {
                            CategoryName = "exfoliators" //4
                        },

                        new Category()
                        {
                            CategoryName = "toners" //5
                        },

                        new Category()
                        {
                            CategoryName = "home accessories" //6
                        },
                    });

                    context.SaveChanges();
                }

                // PRODUCTS
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "THE COMPLETE COLLECTION\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 10,
                            ProductPicture = "sets.png",
                            ProductPictureBack = "sets-back.png",
                            IsAvailable = true,
                            CategoryId = 1
                        },

                        new Product()
                        {
                            ProductName = "NIGHT OIL\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 10,
                            ProductPicture = "night-oil.png",
                            ProductPictureBack = "night-oil-back.png",
                            IsAvailable = true,
                            CategoryId = 2
                        },

                        new Product()
                        {
                            ProductName = "OIL DROPS\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 10,
                            ProductPicture = "oil-drops.png",
                            ProductPictureBack = "oil-drops-back.png",
                            IsAvailable = false,
                            CategoryId = 2
                        },

                    new Product()
                        {
                            ProductName = "EXFOLIATOR\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 20,
                            ProductPicture = "exfoliator.png",
                            ProductPictureBack = "exfoliator-back.png",
                            IsAvailable = true,
                            CategoryId = 4
                        },

                        new Product()
                        {
                            ProductName = "FACE CREAM\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 20,
                            ProductPicture = "face-cream.png",
                            ProductPictureBack = "face-cream-back.png",
                            IsAvailable = false,
                            CategoryId = 3
                        },

                        new Product()
                        {
                            ProductName = "TISSUE BOX\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 10,
                            ProductPicture = "tissue-box.png",
                            ProductPictureBack = "tissue-box-back.png",
                            IsAvailable = true,
                            CategoryId = 6
                        },

                        new Product()
                        {
                            ProductName = "VANITY BAG\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 10,
                            ProductPicture = "vanity-bag.png",
                            ProductPictureBack = "vanity-bag-back.png",
                            IsAvailable = true,
                            CategoryId = 6
                        },

                        new Product()
                        {
                            ProductName = "TONER\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 10,
                            ProductPicture = "toner.png",
                            ProductPictureBack = "toner-back.png",
                            IsAvailable = true,
                            CategoryId = 5
                        },

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
