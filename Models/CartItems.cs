using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("cart-items")]
    public class CartItems
    {
        public int CartId {get;set;}
        public Cart? Cart {get;set;}
        public int ProductId {get;set;}
        public Product? Product {get;set;}
        public int Quantity {get;set;}
    }
}