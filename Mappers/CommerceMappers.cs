using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DTO;
using Ecommerce.DTO.CategoryDTO;
using Ecommerce.Models;

namespace Ecommerce.Mappers
{
    public static class CommerceMappers
    {
        public static ProductDTO ToProductDto(this Product productModel)
        {
            return new ProductDTO
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Price = productModel.Price,
                Description = productModel.Description,
                CreatedAt = productModel.CreatedAt,
                UpdatedAt = productModel.UpdatedAt
            };
        }

        public static Product ToProductFromProductDto(this CreateProductDTO createDto)
        {
            return new Product
            {
                Name = createDto.Name,
                Price = createDto.Price,
                CategoryId = createDto.CategoryId,
                Description = createDto.Description,
                CreatedAt = createDto.CreatedAt ?? DateTime.UtcNow 
            };
        }

        public static CategoryDTO ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDTO
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                ProductCount = categoryModel.Products.Count,
                CreatedAt = categoryModel.CreatedAt,
                UpdatedAt = categoryModel.UpdatedAt 
            };
        }

        public static Category ToCategoryFromCategoryDto(this AddCategoryDTO create)
        {
            return new Category
            {
                Name = create.Name,
                CreatedAt = create.CreatedAt ?? DateTime.UtcNow
            };
        }
    }

}