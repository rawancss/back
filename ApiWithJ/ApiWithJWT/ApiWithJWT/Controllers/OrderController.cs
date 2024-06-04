
using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Ordrers;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto order)
        {
            var createdOrder = await _orderService.CreateOrder(order);
            return CreatedAtAction("GetOrder", new { id = createdOrder.OrderId }, createdOrder);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderDto order)
        {
            var updated = await _orderService.UpdateOrder(id, order);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var deleted = await _orderService.DeleteOrder(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}