using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos;
using Products.Application.Interfaces;

namespace Products.Controllers;

[ApiController]
[Route("app/[controller]")]
public class ProductsController(IProductsService _productsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto, CancellationToken ct)
    {
        if (dto == null)
        {
            return BadRequest("User is null");
        }

        await _productsService.CreateAsync(dto, ct);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _productsService.GetAllAsync(ct));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
    {
        try
        {
            return Ok(await _productsService.GetByIdAsync(id, ct));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto dto, CancellationToken ct)
    {
        try
        {
            await _productsService.UpdateAsync(dto, ct);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
    {
        try
        {
            await _productsService.RemoveAsync(id, ct);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}