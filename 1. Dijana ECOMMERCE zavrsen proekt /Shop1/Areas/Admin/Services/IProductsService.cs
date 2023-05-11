using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shop1.Models;
using Shop1.ViewModels;

namespace Shop1.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> FindByIdAsync(int id);

        Task<Product> GetByProductName(Product product);

        Task<Product> ReturnCategoryByName(int id);

        Task<ProductCategoryDropdownViewModel> GetNewProductCategoryDropdownValues();

        Task AddAsync(Product product);

        Task Update(Product product);

        Task<Product> UpdateAsync(int id, Product product);

        Task DeleteAsync(int id);

        string ProcessUploadedFile(ProductViewModel model);

        string ProcessUploadedFileBack(ProductViewModel model);

        List<Product> GetListProducts();

        List<Product> FilterProductsCategoryId(int? id);

        Task<IEnumerable<Product>> GetAllAsync(string searchStrings);
    }
}