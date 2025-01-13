using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(int Id);
        Task AddProduct(AddProductDTO product);
        Task UpdateProduct (Produc)
    }
}