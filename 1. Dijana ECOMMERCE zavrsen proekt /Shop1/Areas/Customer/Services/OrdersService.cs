using System;
using Shop1.Data;
using Shop1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis;
using Shop1.Areas.Admin.Services;
using Shop1.Services;
using System.Collections;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Shop1.Utility;

namespace Shop1.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _db;

        private readonly IProductsService _productsService;

        private readonly ICategoriesService _categoriesService;

        private readonly IHttpContextAccessor _contextAccessor;


        public OrdersService(IHttpContextAccessor contextAccessor, AppDbContext db, IProductsService productsService, ICategoriesService categoriesService)
        {
            _db = db;
            _productsService = productsService;
            _categoriesService = categoriesService;
            _contextAccessor = contextAccessor;
        }


        public async Task<MergeProductCategory> GetListProducts()
        {
            //var result = _db.Products
            //    .Include(c => c.Categories).ToList();
            //return result;

            //p.CategoryMerged = _categoriesService.GetListCategories();
            //p.ProductMerged = _productsService.GetListProducts();

            var result = new MergeProductCategory()
            {
                //CategoryMerged =  _categoriesService.GetListCategories(),
                ProductMerged = _productsService.GetListProducts()
            };

            return result;
        }


        public MergeProductCategory Merge(int? id)
        {
            MergeProductCategory p = new MergeProductCategory();
            p.CategoryMerged = _categoriesService.GetListCategories();

            if (id == null)
            {
                p.ProductMerged = _productsService.GetListProducts();
            }
            else
            {
                p.ProductMerged = _productsService.FilterProductsCategoryId(id);
            }
            return p;
        }


        public List<Product> Cart()
        {
            List<Product> products = _contextAccessor.HttpContext.Session.Get<List<Product>>("products");

            if (products == null)
            {
                products = new List<Product>();
            }
            return products;
        }


        public async Task<IEnumerable<Product>> Add(int id)
        {
            //var data =  _productsService.GetByIdAsync(id);
            //var result = Cart();

            //result.Add(product);
            //HttpContext.Session.Set("products", products);

            var product = await _productsService.GetByIdAsync(id);
            var products = Cart();

            products.Add(product);
            _contextAccessor.HttpContext.Session.Set("products", products);

            return products;
        }


            public List<Product> Delete(int? id)
        { 
            List<Product> products = _contextAccessor.HttpContext.Session.Get<List<Product>>("products");

            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    _contextAccessor.HttpContext.Session.Set("products", products);
                }
            }
            return products;
        }
    }
}