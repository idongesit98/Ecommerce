using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DTO;
using Ecommerce.DTO.CategoryDTO;
using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category?> GetCategoryById(int id);
        Task<Category?> UpdateCategory(int id, UpdateCategoryDto update);  
        Task<bool> DeleteCategory(int id);

    }
}