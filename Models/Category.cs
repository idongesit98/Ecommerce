using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("Category")]
    public class Category
    {
        public Category() // This constructor initializes products as an empty list when a category is created
        {
            Products = new List<Product>();
        }

        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public ICollection<Product> Products {get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
    }
}