using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.DTO.CartDTO;
using Ecommerce.Interfaces;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CartRepository : ICartRepository
    {
        public AppDbContext _context {get;}
        public CartRepository(AppDbContext context){
            _context = context;
        }
        public async Task AddToCart(AddToCartDTO addCart)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == addCart.UserId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = addCart.UserId,
                    CartItems = new List<CartItems>(),
                };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }
            CartItems ct = _context.CartItems.Find(addCart.ProductId, cart.Id);
            if(ct == null)
            {
                cart = new Cart
                {
                    UserId = addCart.UserId,
                    CartItems = new List<CartItems>()
                };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }else
            {
                ct.Quantity++;
            }
            await _context.SaveChangesAsync();   
        }

        public async Task<ICollection<Product>> GetAll(string UserId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == UserId);
            if(cart == null)
            {
                cart = new Cart
                {
                    UserId = UserId,
                    CartItems = new List<CartItems>(),
                };
            }
            return _context.CartItems
                    .Where(ct => ct.CartId == cart.Id)
                    .Select(ct => ct.Product)
                    .ToList();
        }

        public async Task<decimal> GetPrice(string UserId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == UserId);
            if(cart == null)
            {
                cart = new Cart
                {
                    UserId = UserId,
                    CartItems = new List<CartItems>(),
                };
            }
            return _context.CartItems
                .Where(ct => ct.CartId == cart.Id)
                .Select(ct => ct.Product.Price * ct.Quantity)
                .Sum();
        }

        public async Task RemoveProduct(AddToCartDTO removeCart)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == removeCart.UserId);
            if(cart == null)
            {
                cart = new Cart
                {
                    UserId = removeCart.UserId,
                    CartItems = new List<CartItems>(),
                };
            }
            var ct = _context.CartItems.Find(removeCart.ProductId, cart.Id);
            if(ct == null)
            {
                return;
            }
            if(ct.Quantity > 1)
            {
                ct.Quantity--;
            }
            else{
                _context.CartItems.Remove(ct);
            }
            await _context.SaveChangesAsync();
        }
    }
}