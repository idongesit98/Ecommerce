using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("order")]
    public class Order
    {
        public int Id {get;set;}
        public decimal Amount {get;set;}
        public AppUser User {get;set;}
        public ICollection<Product> Products {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
        // Payment method
        public PaymentMethods Method {get;set;}
    }
}