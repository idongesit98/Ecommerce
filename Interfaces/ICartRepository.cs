using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DTO.CartDTO;
using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface  ICartRepository
    {
        Task<ICollection<Product>> GetAll(string UserId);
        Task<decimal> GetPrice(string UserId);
        Task AddToCart(AddToCartDTO addCart);
        Task RemoveProduct(AddToCartDTO removeCart);
    }
}