using System.Collections.Generic;
using System.Threading.Tasks;
using proba6.Models;

namespace proba6.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<IEnumerable<Product>> GetAllAsync(string searchStrings);

        Task<Product> GetProductByIdAsync(int id);  

        Task AddNewProductAsync(NewProductVm data);  

        Task<NewProductCategoryDropdownVM> GetNewProductCategoryDropdownValues();  

        Task<Product> UpdateAsync(int id, Product newProduct);

        Task UpdateMovieAsync(NewProductVm data);  

        Task DeleteAsync(int id);
    }
}
