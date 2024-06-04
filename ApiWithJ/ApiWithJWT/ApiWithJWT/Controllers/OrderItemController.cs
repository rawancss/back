
using ApiWithJWT.Dtos.OrderItems;
using ApiWithJWT.Dtos.Ordrers;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItems()
        {
            var orderItems = await _orderItemService.GetOrderItems();
            return orderItems;
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItem(Guid id)
        {
            var orderItem = await _orderItemService.GetOrderItem(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> CreateOrderItem(CreateOrderItemDto orderItem)
        {
            var createdOrderItem = await _orderItemService.CreateOrderItem(orderItem);
            return CreatedAtAction("GetOrderItem", new { id = createdOrderItem.OrderItemId }, createdOrderItem);
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(Guid id, UpdateOrderItemDto orderItem)
        {
            var updated = await _orderItemService.UpdateOrderItem(id, orderItem);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var deleted = await _orderItemService.DeleteOrderItem(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}



