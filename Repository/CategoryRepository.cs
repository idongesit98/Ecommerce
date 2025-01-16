using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.DTO.CategoryDTO;
using Ecommerce.Interfaces;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        public AppDbContext _context{get;}
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            var categoryDTO = categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                ProductCount = c.Products.Count 
            });
            return(ICollection<Category>)categoryDTO;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
           return await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Category?> UpdateCategory(int id, UpdateCategoryDto update)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
                return null;

                existingCategory.Name = update.Name;
                await _context.SaveChangesAsync();
                return existingCategory;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var deleteCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(deleteCategory == null)
                return null;

                _context.Categories.Remove(deleteCategory);
                await _context.SaveChangesAsync();
                return deleteCategory;
        }
    }
}