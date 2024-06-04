using ApiWithJWT.Dtos.OrderItems;
using ApiWithJWT.Models;

namespace ApiWithJWT.Services.Interfaces;
public interface IOrderItemService
{
    Task<OrderItemDto> CreateOrderItem(CreateOrderItemDto orderItem);
    Task<bool> DeleteOrderItem(Guid id);
    Task<OrderItemDto> GetOrderItem(Guid id);
    Task<List<OrderItemDto>> GetOrderItems();
    Task<bool> UpdateOrderItem(Guid id, UpdateOrderItemDto orderItem);
}