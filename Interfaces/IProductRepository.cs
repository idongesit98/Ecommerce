using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DTO;
using Ecommerce.DTO.UpdateDTO;
using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();
        Task<Product> GetProductById(int Id);
        Task<Product> CreateProduct(Product createProduct);
        Task<Product> UpdateProduct (int id, UpdateDTO update);
        Task<Product> DeleteProduct(int id);
    }
}