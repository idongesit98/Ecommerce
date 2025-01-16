using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO.CategoryDTO
{
    public class CategoryDTO
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public int ProductCount {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
    }
}