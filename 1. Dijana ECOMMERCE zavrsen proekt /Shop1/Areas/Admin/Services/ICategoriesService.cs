using System;
using Shop1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop1.Areas.Admin.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        List<Category> GetListCategories();

        Task<Category> GetByIdAsync(int id);

        Task<Category> GetByCategoryName(Category category);

        Task AddAsync(Category category);

        Task<Category> UpdateAsync(int id, Category category);

        Task DeleteAsync(int id);
    }
}

