using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        public int Id {get;set;}
        public int CategoryId {get;set;}
        public string Name {get;set;}
        public string CategoryName {get;set;}
        public decimal Price {get;set;}
        public string Description {get;set;}
    }
}