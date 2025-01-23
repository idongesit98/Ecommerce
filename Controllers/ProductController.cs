using Ecommerce.Data;
using Ecommerce.DTO;
using Ecommerce.DTO.UpdateDTO;
using Ecommerce.Interfaces;
using Ecommerce.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[ApiController]
[Route("api/product")]
[Authorize]
public class CommerceController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _prodRepo;

    public CommerceController(AppDbContext context, IProductRepository prodRepo)
    {
        _context = context;
        _prodRepo = prodRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

         var product = await _prodRepo.GetProducts();
         var productDTO = product.Select(s => s.ToProductDto()).ToList();
         return Ok(productDTO);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id){
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

         var product = await _prodRepo.GetProductById(id);  
         if(product == null)
            return NotFound();

            return Ok(product);            
    }

    [HttpPost("create")]
    public async Task<IActionResult>CreateProduct([FromBody] CreateProductDTO create)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createModel = create.ToProductFromProductDto();
        await _prodRepo.CreateProduct(createModel);
        return CreatedAtAction(nameof(GetById), new{id = createModel.Id},createModel.ToProductDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateDTO update)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var updateModel = await _prodRepo.UpdateProduct(id,update);
        if(updateModel == null)
            return NotFound();

            return Ok(updateModel.ToProductDto());  
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var deleteProduct = await _prodRepo.DeleteProduct(id);
            if(deleteProduct == null)
                return NotFound(new {message = "Product was not found"});

                return Ok(new {message = "Product deleted successfully"});
    }

    
}
