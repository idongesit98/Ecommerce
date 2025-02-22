using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CreateProductDTO
    {
        [Required]
        public string Name {get;set;}
        [Required]
        public decimal Price {get;set;}
        [Required]
        public int CategoryId {get;set;}
        public string Description {get;set;} = string.Empty;
        public DateTime? CreatedAt {get;set;} 
    }
}