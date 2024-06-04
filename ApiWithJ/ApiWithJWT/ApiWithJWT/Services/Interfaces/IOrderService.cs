using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Ordrers;

namespace ApiWithJWT.Services.Interfaces;
public interface IOrderService
{
    Task<OrderDto> CreateOrder(CreateOrderDto order);
    Task<bool> DeleteOrder(Guid id);
    Task<OrderDto> GetOrder(Guid id);
    Task<List<OrderDto>> GetOrders();
    Task<bool> UpdateOrder(Guid id, UpdateOrderDto order);
}