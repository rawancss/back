
using ApiWithJWT.Data;
using ApiWithJWT.Dtos.OrderItems;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithJWT.Services
{
	public class OrderItemService : IOrderItemService
	{
		private readonly ApplicationDbContext _context;

		public OrderItemService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<OrderItemDto>> GetOrderItems()
		{
			var orderItems = await _context.OrderItems.ToListAsync();
			return orderItems.Select(orderItem => new OrderItemDto
			{
				OrderItemId = orderItem.OrderItemId,
				OrderId = orderItem.OrderId,
				Price = orderItem.Price,
				Quantity = orderItem.Quantity,
			}).ToList();
		}

		public async Task<OrderItemDto> GetOrderItem(Guid id)
		{
			var orderItem = await _context.OrderItems.FindAsync(id);
			return new OrderItemDto
			{
				OrderItemId = orderItem.OrderItemId,
				OrderId = orderItem.OrderId,
				Price = orderItem.Price,
				Quantity = orderItem.Quantity,
			};
		}

		public async Task<OrderItemDto> CreateOrderItem(CreateOrderItemDto orderItem)
		{
			var newOrderItem = new OrderItem
			{
				OrderItemId = Guid.NewGuid(),
				OrderId = orderItem.OrderId,
				Price = orderItem.Price,
				Quantity = orderItem.Quantity,
			};
			_context.OrderItems.Add(newOrderItem);
			await _context.SaveChangesAsync();

			return new OrderItemDto
			{
				OrderItemId = newOrderItem.OrderItemId,
				OrderId = newOrderItem.OrderId,
				Price = newOrderItem.Price,
				Quantity = newOrderItem.Quantity,
			};
		}

		public async Task<bool> UpdateOrderItem(Guid id, UpdateOrderItemDto orderItem)
		{
			var orderItemToUpdate = await _context.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
			if (orderItemToUpdate is null)
			{
				return false;
			}

			orderItemToUpdate.Price = orderItem.Price;
			orderItemToUpdate.Quantity = orderItem.Quantity;
			orderItemToUpdate.OrderId = orderItem.OrderId;
			orderItemToUpdate.ProductId = orderItem.ProductId;

			_context.Entry(orderItem).State = EntityState.Modified;

			await _context.SaveChangesAsync();


			return true;
		}

		public async Task<bool> DeleteOrderItem(Guid id)
		{
			var orderItem = await _context.OrderItems.FindAsync(id);
			if (orderItem == null)
			{
				return false;
			}

			_context.OrderItems.Remove(orderItem);
			await _context.SaveChangesAsync();

			return true;
		}

	
	}
}