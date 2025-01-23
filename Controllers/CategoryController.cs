using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.DTO.CategoryDTO;
using Ecommerce.Interfaces;
using Ecommerce.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController:ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICategoryRepository _catRepo;

        public CategoryController(AppDbContext context, ICategoryRepository catRepo)
        {
            _context = context;
            _catRepo = catRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult>GetAllCategories()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var category = await _catRepo.GetCategories();
                if(category == null)
                    return NotFound();

             return Ok(category);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
                var category = await _catRepo.GetCategoryById(id);

                if(category == null)
                    return NotFound();
                return Ok(category);
        }

        [HttpPost("create")]
        public async Task<IActionResult>CreateCategory([FromBody] AddCategoryDTO addCategory)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var createCategory = addCategory.ToCategoryFromCategoryDto();
                await _catRepo.CreateCategory(createCategory);
                return CreatedAtAction(nameof(GetCategoryById), new {id = createCategory.Id}, createCategory.ToCategoryDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateCategoryDto update) // start from here test this route
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var updateModel = await _catRepo.UpdateCategory(id,update);
                if(updateModel == null)
                    return BadRequest(ModelState);

                return Ok(updateModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var deleteProduct = await _catRepo.DeleteCategory(id);
                if(deleteProduct)
                    return NotFound(new {message = "Category not found"});
                return Ok(new {message = "Category deleted successfully"});
        }        
    }
}