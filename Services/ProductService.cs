using Mapster;
using MarketPlays.Database;
using MarketPlays.Entities;
using MarketPlays.Extensions.AddServiceFromAttribute;
using MarketPlays.Interfaces;
using MarketPlays.Models.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace MarketPlays.Services;

[Scoped]
public class ProductService : IProductService
{
    private readonly AppDbContext context;
    public ProductService (AppDbContext _context)
    {
        context = _context;
    }

    public async Task AddProduct(GetProductDto getProductDto, Guid orgId)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = getProductDto.Name,
            Description = getProductDto.Description,
            organisationId = orgId,
        };
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProduct(Guid ProductId)
    {
        var product = await context.Products.FirstAsync(p => p.Id == ProductId);
        context.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<List<SendProductDto>> GetProductList()
    {
        var list = await context.Products.Select(p => p.Adapt<SendProductDto>()).ToListAsync();
        return list;
    }

    public async Task<SendProductDto> GetProduct(Guid productId)
    {
       var product = await context.Products.FirstAsync(p => p.Id == productId);
        return product.Adapt<SendProductDto>();
    }

    public async Task UpdateProduct(Guid productId, UpdateProductDto updateProductDto)
    {
        var product = await context.Products.FirstAsync(p => p.Id == productId);
        product.Description = updateProductDto.Description;
        product.Name = updateProductDto.Name;
        await context.SaveChangesAsync();
    }
}