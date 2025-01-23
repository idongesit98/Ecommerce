using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DTO.CartDTO;
using Ecommerce.Interfaces;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController:ControllerBase
    {
        ICartRepository cartRepository;
        IProductRepository productRepository;
        UserManager<AppUser> userManager;

        public CartController(ICartRepository cartRepository, UserManager<AppUser> userManager, IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
            this.productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartDTO addCart)
        {
            var user = await userManager.FindByIdAsync(addCart.UserId);
            var product = await productRepository.GetProductById(addCart.ProductId);
            if(user == null)
                return BadRequest("User not found.");

            if(product == null)
             return BadRequest("Product not found.");

            await cartRepository.AddToCart(addCart);
            return Ok();     
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return BadRequest();
            }
            var product = await cartRepository.GetAll(userId);
            return Ok(product);
        }

        [HttpGet("cost")]
        public async Task<IActionResult> GetCost(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if(user == null)
                return BadRequest();

            var cost = await cartRepository.GetPrice(userId);
            return Ok(cost);    
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(AddToCartDTO addDto)
        {
            var user = await userManager.FindByIdAsync(addDto.UserId);
            if(user == null)
                BadRequest();

                await cartRepository.RemoveProduct(addDto);
                return Ok();
        }
    }
}