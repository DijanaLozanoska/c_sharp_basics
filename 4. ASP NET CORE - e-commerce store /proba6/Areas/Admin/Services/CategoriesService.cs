using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proba6.Data;
using proba6.Models;

namespace proba6.Services
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

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _db.Categories.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task AddAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task<Category> UpdateAsync(int id, Category newCategory)
        {
            _db.Update(newCategory);
            await _db.SaveChangesAsync();
            return newCategory;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _db.Categories.FirstOrDefaultAsync(n => n.Id == id);
            _db.Categories.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}

