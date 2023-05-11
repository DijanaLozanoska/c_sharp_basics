using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Shop1.Data;
using Shop1.Models;
using Shop1.ViewModels;

namespace Shop1.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _db;

        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsService(AppDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _db.Products
                .Include(c => c.Categories).ToListAsync();
            return result;
        }


        public List<Product> GetListProducts()
        {
            var result = _db.Products
                .Include(c => c.Categories).ToList();
            return result;
        }


        public List<Product> FilterProductsCategoryId(int? id)
        {
            var result = _db.Products.Where(c => c.CategoryId == id).ToList();
            return result;
        }



        public async Task<Product> GetByIdAsync(int id)
        {
            var result = await _db.Products
                .Include(c => c.Categories).FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

     
        //public async Task<Product> GetByIdAsync(int id)
        //{
        //    var result =  _db.Products
        //        .Include(c => c.Categories).FirstOrDefault(n => n.Id == id);
        //    return result;
        //}


        public async Task<Product> FindByIdAsync(int id)
        {
            var result = await _db.Products.FindAsync(id);
            return result;
        }


        public async Task<Product> GetByProductName(Product product)
        {
            var result = _db.Products.
                FirstOrDefault(n => n.ProductName == product.ProductName);
            return result;
        }


        public async Task<Product> ReturnCategoryByName(int id)
        {
            var result = await _db.Set<Product>()
                .Include(c => c.Categories).FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }


        // ova e za search
        public async Task<IEnumerable<Product>> GetAllAsync(string searchStrings)
        {
            IQueryable<Product> query = _db.Set<Product>();
            query = searchStrings.Aggregate(query, (current, searchString) => current.Include(Char.ToString(searchString)));
            return await query.ToListAsync();
        }

        public async Task<ProductCategoryDropdownViewModel> GetNewProductCategoryDropdownValues()
        {
            var result = new ProductCategoryDropdownViewModel()
            {
                Categories = await _db.Categories.OrderBy(n => n.CategoryName).ToListAsync(),
            };

            return result;
        }


        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }


        public async Task Update(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }


        public async Task<Product> UpdateAsync(int id, Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }


        public async Task DeleteAsync(int id)
        {
            var result = await _db.Products.FirstOrDefaultAsync(n => n.Id == id);
            _db.Products.Remove(result);
            await _db.SaveChangesAsync();
        }


        public string ProcessUploadedFile(ProductViewModel model)
        {
            string uniqueFileName = null;

            string path = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.ProductPictureUpload != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductPictureUpload.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductPictureUpload.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


        public string ProcessUploadedFileBack(ProductViewModel model)
        {
            string uniqueFileNameBack = null;

            string path = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.ProductPictureUploadBack != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                uniqueFileNameBack = Guid.NewGuid().ToString() + "_" + model.ProductPictureUploadBack.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameBack);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductPictureUploadBack.CopyTo(fileStream);
                }
            }

            return uniqueFileNameBack;
        }
    }
}

