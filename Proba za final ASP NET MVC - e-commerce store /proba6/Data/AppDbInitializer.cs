using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using proba6.Models;

namespace proba6.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Products
                //if (!context.Products.Any())
                //{
                //    context.Products.AddRange(new List<Product>()
                //    {
                //        new Product()
                //        {
                //            ProductName = "Product 11",
                //            ProductDescription = "Description 11",
                //            ProductPrice = 11.00m,
                //            //ProductPicture =
                //            IsAvailable = true,
                //            //CategoryId = 3,

                //        },
                //        new Product()
                //        {
                //            ProductName = "Product 22",
                //            ProductDescription = "Description 22",
                //            ProductPrice = 22.00m,
                //            //ProductPicture =
                //            IsAvailable = true,
                //            //CategoryId = 2,
                //        },
                //        new Product()
                //        {
                //            ProductName = "Product 33",
                //            ProductDescription = "Description 33",
                //            ProductPrice = 33.00m,
                //            //ProductPicture =
                //            IsAvailable = false,
                //            //CategoryId = 5,
                //        }
                //    }); 

                //    context.SaveChanges();
                //}

                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {                        
                            CategoryName = "face"
                        },
                        new Category()
                        {
                            CategoryName = "lips"
                        },
                            new Category()
                        {
                            CategoryName = "eyes"
                        },
                            new Category()
                        {
                            CategoryName = "body"
                        },
                            new Category()
                        {
                            CategoryName = "new"
                        },
                    }); 

                    context.SaveChanges();
                }

                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            CategoryName = "face"
                        },
                        new Category()
                        {
                            CategoryName = "lips"
                        },
                            new Category()
                        {
                            CategoryName = "eyes"
                        },
                            new Category()
                        {
                            CategoryName = "body"
                        },
                            new Category()
                        {
                            CategoryName = "new"
                        },
                    });

                    context.SaveChanges();
                }

            }
        }
    }
}
