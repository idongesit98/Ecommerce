using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.DTO;
using Ecommerce.DTO.UpdateDTO;
using Ecommerce.Interfaces;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductRepository:IProductRepository
    {
        public AppDbContext _context {get;}

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            var productDTO = products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name,
                CategoryId = p.Category.Id,
                Description = p.Description
            }).ToList();
            return (ICollection<Product>)productDTO;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return null;
            }
            var productDTO = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.Category.Id,
                Description = product.Description
            };
            return productDTO;
        }

        public async Task<Product> CreateProduct(Product createProduct)
        {
            // var addProduct = new Product
            // {
            //     Name = createProduct.Name,
            //     Price = createProduct.Price,
            //     CategoryId = createProduct.CategoryId,
            //     Description = createProduct.Description,
            // };
            await _context.Products.AddAsync(createProduct);
            await _context.SaveChangesAsync();
            return createProduct;
        }

        public async Task<Product> UpdateProduct(int id,UpdateDTO update)
        { 
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x =>x.Id == id);
            if(existingProduct == null)
                return null;

            existingProduct.Name = update.Name;
            existingProduct.Description = update.Description;
            existingProduct.Price = update.Price;
            existingProduct.Category = update.Category;
            existingProduct.UpdatedAt = update.UpdatedAt;    
            
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return null;

             _context.Products.Remove(product);
             await _context.SaveChangesAsync();
             return product;   
        }
    }
}