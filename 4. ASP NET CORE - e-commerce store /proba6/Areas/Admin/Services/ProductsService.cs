using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proba6.Data;
using proba6.Models;

namespace proba6.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _db;

        public ProductsService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _db.Products
                .Include(c => c.Categories).ToListAsync();
            return result;
        }


        public async Task<IEnumerable<Product>> GetAllAsync(string searchStrings)
        {
            IQueryable<Product> query = _db.Set<Product>();
            query = searchStrings.Aggregate(query, (current, searchString) => current.Include(Char.ToString(searchString)));
            return await query.ToListAsync();
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _db.Products
                .Include(c => c.Categories).FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }


        public async Task AddNewProductAsync(NewProductVm data)
        {
            var newProduct = new Product()
            {
                ProductName = data.ProductName,
                ProductDescription = data.ProductDescription,
                ProductPrice = data.ProductPrice,
                ProductPicture = data.ProductPicture,
                IsAvailable = data.IsAvailable,
                CategoryId = data.CategoryId,
            };
            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
        }


        public async Task<NewProductCategoryDropdownVM> GetNewProductCategoryDropdownValues()
        {
            var response = new NewProductCategoryDropdownVM()
            {
                Categories = await _db.Categories.OrderBy(n => n.CategoryName).ToListAsync(),
            };

            return response;
        }


        public async Task<Product> UpdateAsync(int id, Product newProduct)
        {
            _db.Update(newProduct);
            await _db.SaveChangesAsync();
            return newProduct;
        }


        public async Task UpdateMovieAsync(NewProductVm data)
        {
            var dbProduct = await _db.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.ProductName = data.ProductName;
                dbProduct.ProductDescription = data.ProductDescription;
                dbProduct.ProductPrice = data.ProductPrice;
                dbProduct.ProductPicture = data.ProductPicture;
                dbProduct.IsAvailable = data.IsAvailable;
                dbProduct.CategoryId = data.CategoryId;
                await _db.SaveChangesAsync();
            }
            await _db.SaveChangesAsync();
        }
    

        public async Task DeleteAsync(int id)
        {
            var result = await _db.Products.FirstOrDefaultAsync(n => n.Id == id);
            _db.Products.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}

