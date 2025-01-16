using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        public int Id {get;set;}
        public string Name {get;set;}
         public decimal Price {get;set;}
        public string Description {get;set;}
        public int CategoryId {get;set;}     
        public string CategoryName {get;set;}
        public Category Category{get;set;}
        public ICollection<Cart> Cart {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;     
    }
}