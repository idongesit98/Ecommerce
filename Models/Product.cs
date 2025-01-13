using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("product")]
    public class Product
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public decimal Price {get;set;}
        public string Description{get;set;} = string.Empty;
        public int CategoryId{get;set;}
        public Category Category{get;set;}
        public ICollection<Cart> Cart {get;set;}

    }
}