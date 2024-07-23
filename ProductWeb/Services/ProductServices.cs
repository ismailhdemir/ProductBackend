using ProductWeb.Repositories.Interfaces;
using ProductWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductWeb.Models;
namespace ProductWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }

            newProduct.CreationDate = DateTime.Now; 

            return await _productRepository.CreateAsync(newProduct);
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                throw new ArgumentNullException(nameof(updatedProduct));
            }

            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return null; 
            }

            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.StockQuantity = updatedProduct.StockQuantity;
            existingProduct.ProductGroupId = updatedProduct.ProductGroupId;

            return await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false; 
            }

            return await _productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetProductsByKeywordAsync(string keyword)
        {
            return await _productRepository.GetByKeywordAsync(keyword);
        }
    }
}
