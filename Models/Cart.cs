using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("cart")]
    public class Cart
    {
        public int Id {get;set;}
        public string? UserId {get;set;}
        public ICollection<CartItems>? CartItems {get;set;}
    }
}