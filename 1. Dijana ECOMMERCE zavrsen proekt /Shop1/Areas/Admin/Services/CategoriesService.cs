using System;
using Shop1.Data;
using Shop1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Shop1.Areas.Admin.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _db;

        public CategoriesService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = await _db.Categories.ToListAsync();
            return result;
        }


        public List<Category> GetListCategories()
        {
            var result = _db.Categories.ToList();
            return result;
        }


        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _db.Categories.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }


        public async Task<Category> GetByCategoryName(Category category)
        {
            var result = _db.Categories.FirstOrDefault(n => n.CategoryName == category.CategoryName);
            return result;
        }


        public async Task AddAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }


        public async Task<Category> UpdateAsync(int id, Category category)
        {
            _db.Update(category);
            await _db.SaveChangesAsync();
            return category;
        }


        public async Task DeleteAsync(int id)
        {
            var result = await _db.Categories.FirstOrDefaultAsync(n => n.Id == id);
            _db.Categories.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}

