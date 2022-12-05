using MarketPlays.Models.ProductDtos;
namespace MarketPlays.Interfaces;

public interface IProductService
{
    Task AddProduct(GetProductDto getProductDto, Guid ProductId);
    Task<SendProductDto> GetProduct(Guid id);
    Task <List<SendProductDto>>GetProductList();
    Task UpdateProduct(Guid productId, UpdateProductDto updateProductDto);
    Task DeleteProduct(Guid Id);
}