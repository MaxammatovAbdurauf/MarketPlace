using MarketPlays.Interfaces;
using MarketPlays.Models.ProductDtos;
using MarketPlays.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService productService;
    public ProductController (ProductService _productService)
    {
        productService = _productService;
    }

    [HttpPost]
    public async Task AddProduct(GetProductDto getProductDto, Guid productId)
    {
        if (!ModelState.IsValid) throw new Exception();
        await productService.AddProduct(getProductDto, productId);
    }

    [HttpDelete]
    public async Task DeleteProduct(Guid Id)
    {
        await productService.DeleteProduct(Id);
    }

    [HttpGet("all")]
    public async Task<List<SendProductDto>> GetProductList()
    {
        return await productService.GetProductList();
    }

    [HttpGet("one")]
    public async Task<SendProductDto> GetProduct(Guid id)
    {
        return await productService.GetProduct(id);
    }

    [HttpPut]
    public async Task UpdateProduct(UpdateProductDto updateProductDto, Guid productId)
    {
        if (!ModelState.IsValid) throw new Exception();
        await productService.UpdateProduct(productId, updateProductDto);
    }
}
