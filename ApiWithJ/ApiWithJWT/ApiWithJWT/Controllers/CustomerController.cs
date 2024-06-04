using ApiWithJWT.Dtos.Users;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _userService;

        public CustomerController(ICustomerService userService)
        {
            _userService = userService;
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var users = await _userService.GetAllCustomersAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid id)
        {
            var user = await _userService.GetCustomerByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }


        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var success = await _userService.DeleteCustomerAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
