using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO.CategoryDTO
{
    public class AddCategoryDTO
    {
        public string Name {get;set;} = string.Empty;
        public DateTime? CreatedAt{get;set;} = DateTime.UtcNow;
    }

    public class UpdateCategoryDto
    {
        public string Name {get;set;} = string.Empty;
        public DateTime? UpdatedAt{get;set;}
    }
}