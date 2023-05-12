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
                            ProductPrice = 500,
                            ProductPicture = "sets.png",
                            ProductPictureBack = "sets-back.png",
                            IsAvailable = true,
                            CategoryId = 1
                        },

                        new Product()
                        {
                            ProductName = "THE STARTER BUNDLE\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 200,
                            ProductPicture = "the-starter-bundle.png",
                            ProductPictureBack = "the-starter-bundle-back.png",
                            IsAvailable = true,
                            CategoryId = 1
                        },

                        new Product()
                        {
                            ProductName = "THE ESSENTIALS\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 200,
                            ProductPicture = "the-essentials.png",
                            ProductPictureBack = "the-essentials-back.png",
                            IsAvailable = true,
                            CategoryId = 1
                        },

                        new Product()
                        {
                            ProductName = "THE BASICS\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 200,
                            ProductPicture = "basics.png",
                            ProductPictureBack = "basics-back.png",
                            IsAvailable = false,
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

                        // category : moisturizers
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
                            ProductName = "EYE CREAM\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 20,
                            ProductPicture = "eye-cream.png",
                            ProductPictureBack = "eye-cream-back.png",
                            IsAvailable = false,
                            CategoryId = 3
                        },

                        // category : exfoliators
                        new Product()
                        {
                            ProductName = "EXFOLIATOR\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 30,
                            ProductPicture = "exfoliator.png",
                            ProductPictureBack = "exfoliator-back.png",
                            IsAvailable = true,
                            CategoryId = 4
                        },

                        new Product()
                        {
                            ProductName = "CLEANSER\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 30,
                            ProductPicture = "cleanser.png",
                            ProductPictureBack = "cleanser-back.png",
                            IsAvailable = true,
                            CategoryId = 4
                        },

                        // category : toner 
                        new Product()
                        {
                            ProductName = "TONER\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 70,
                            ProductPicture = "toner.png",
                            ProductPictureBack = "toner-back.png",
                            IsAvailable = true,
                            CategoryId = 5
                        },

                        new Product()
                        {
                            ProductName = "HYALURONIC ACID SERUM\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 60,
                            ProductPicture = "hyaluronic-acid.png",
                            ProductPictureBack = "hyaluronic-acid-back.png",
                            IsAvailable = false,
                            CategoryId = 5
                        },

                        // category : home accessories 
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
                            ProductName = "ROUND CONTAINER\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 100,
                            ProductPicture = "round-container.png",
                            ProductPictureBack = "round-container-back.png",
                            IsAvailable = true,
                            CategoryId = 6
                        },

                        new Product()
                        {
                            ProductName = "VANITY TRAY\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 100,
                            ProductPicture = "vanity-tray.png",
                            ProductPictureBack = "vanity-tray-back.png",
                            IsAvailable = true,
                            CategoryId = 6
                        },

                        new Product()
                        {
                            ProductName = "CANISTER\n",
                            ProductDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ProductPrice = 100,
                            ProductPicture = "canister.png",
                            ProductPictureBack = "canister-back.png",
                            IsAvailable = true,
                            CategoryId = 6
                        },

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
