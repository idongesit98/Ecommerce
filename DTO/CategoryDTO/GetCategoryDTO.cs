using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO.CategoryDTO
{
    public class GetCategoryDTO
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int ProductCount {get;set;}
    }
}