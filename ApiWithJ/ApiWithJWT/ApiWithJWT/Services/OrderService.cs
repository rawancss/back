
using ApiWithJWT.Data;
using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Ordrers;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithJWT.Services
{
	public class OrderService : IOrderService
	{
		private readonly ApplicationDbContext _context;

		public OrderService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<OrderDto>> GetOrders()
		{
			var orders = await _context.Orders.ToListAsync();
			return orders.Select(order => new OrderDto
			{
				AddressId = order.AddressId,
				CustomerId = order.CustomerId,
				OrderDate = order.OrderDate,
				OrderId = order.OrderId,
				Status = order.Status,
				TotalPrice = order.TotalPrice,
			}).ToList();
		}

		public async Task<OrderDto> GetOrder(Guid id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order == null)
				return new OrderDto();

			return new OrderDto
			{
				OrderId = order.OrderId,
				OrderDate = order.OrderDate,
				Status = order.Status,
				TotalPrice = order.TotalPrice,
			};
		}

		public async Task<OrderDto> CreateOrder(CreateOrderDto order)
		{
			var address = new ShippingAddress
			{
				AddressId = Guid.NewGuid(),
				CustomerId = order.CustomerId,
				AddressLine1 = order.Address.AddressLine1,
				City = order.Address.City,
				Country = order.Address.Country,
				State = order.Address.State,
			};
			var newOrder = new Order
			{
				OrderId = Guid.NewGuid(),
				ShippingAddress = address,
				CustomerId = order.CustomerId,
				OrderDate = DateTime.UtcNow,

				Status = order.Status,
				TotalPrice = order.TotalPrice,
			};
			_context.Orders.Add(newOrder);
			await _context.SaveChangesAsync();

			return new OrderDto
			{
				OrderId = newOrder.OrderId,
				AddressId = newOrder.AddressId,
				CustomerId = newOrder.CustomerId,
				OrderDate = newOrder.OrderDate,

			};
		}

		public async Task<bool> UpdateOrder(Guid id, UpdateOrderDto order)
		{
			var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
			if (orderToUpdate is null)
			{
				return false;
			}

			orderToUpdate.OrderDate = order.OrderDate;
			orderToUpdate.Status = order.Status;
			orderToUpdate.TotalPrice = order.TotalPrice;
			orderToUpdate.AddressId = order.AddressId;
			orderToUpdate.CustomerId = order.CustomerId;


			_context.Entry(order).State = EntityState.Modified;

			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteOrder(Guid id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order == null)
			{
				return false;
			}

			_context.Orders.Remove(order);
			await _context.SaveChangesAsync();

			return true;
		}


	}
}