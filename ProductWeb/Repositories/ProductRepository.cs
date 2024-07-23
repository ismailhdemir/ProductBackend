using Microsoft.EntityFrameworkCore;
using ProductWeb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWeb.Models;
namespace ProductWeb.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> CreateAsync(Product newProduct)
        {
            if (newProduct == null) throw new ArgumentNullException(nameof(newProduct));
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> UpdateAsync(Product updatedProduct)
        {
            if (updatedProduct == null) throw new ArgumentNullException(nameof(updatedProduct));
            _context.Products.Update(updatedProduct);
            await _context.SaveChangesAsync();
            return updatedProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetByKeywordAsync(string keyword)
        {
            return await _context.Products.Where(p => p.ProductName.Contains(keyword)).ToListAsync();
        }
    }
}
