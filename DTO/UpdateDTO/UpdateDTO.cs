using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.DTO.UpdateDTO
{
    public class UpdateDTO
    {
        public string Name {get;set;} = string.Empty;
        public decimal Price {get;set;}
        public string Description{get;set;} = string.Empty;
        public int CategoryId{get;set;}
        public Category Category{get;set;}
        public ICollection<Cart> Cart {get;set;}
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
    }
}