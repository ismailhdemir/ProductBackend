using ProductWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductWeb.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> CreateProductAsync(Product newProduct);
        Task<Product> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
        Task<List<Product>> GetProductsByKeywordAsync(string keyword);
    }
}
