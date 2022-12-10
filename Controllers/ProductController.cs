using MarketPlays.Filters;
using MarketPlays.Interfaces;
using MarketPlays.Models.ProductDtos;
using MarketPlays.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IProductService productService;
    public ProductController (IProductService _productService)
    {
        productService = _productService;
    }

    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddProduct(GetProductDto getProductDto, Guid organisationId)
    {
        if (!ModelState.IsValid) throw new Exception();
        await productService.AddProduct(getProductDto, organisationId);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
        await productService.DeleteProduct(Id);
        return Ok();
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SendProductDto>))]
    public async Task<ActionResult<List<SendProductDto>>> GetProductList()
    {
        return  Ok(await productService.GetProductList());
    }

    [HttpGet("one")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SendProductDto))]
    public async Task<ActionResult<SendProductDto>> GetProduct(Guid id)
    {
        return Ok(await productService.GetProduct(id));
    }

    [HttpPut]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto, Guid productId)
    {
        if (!ModelState.IsValid) throw new Exception();
        await productService.UpdateProduct(productId, updateProductDto);
        return Ok();
    }
}