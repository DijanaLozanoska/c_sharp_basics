using System.Collections.Generic;
using System.Threading.Tasks;
using proba6.Models;

namespace proba6.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int id);

        Task AddAsync(Category category);

        Task<Category> UpdateAsync(int id, Category newCategory);

        Task DeleteAsync(int id);
    }
}
