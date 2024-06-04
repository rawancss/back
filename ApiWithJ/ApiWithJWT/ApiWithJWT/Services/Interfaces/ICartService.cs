using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Carts;

namespace ApiWithJWT.Services.Interfaces;
public interface ICartService
{
    Task<bool> DeleteCartInfo(Guid cartId);
    Task<List<CartDto>> GetAllCartService();
    Task<CartDto> GetCartInfoById(Guid cartId);
    Task<bool> NewCartInfos(Guid cartId);
    Task<bool> UpdateCartService(Guid cartId, UpdateCartDto updateCart);
    Task<CartDto> CreateCart(CreateCartDto createCartDto);
}