using ApiWithJWT.Dtos.Users;

namespace ApiWithJWT.Services.Interfaces;
public interface ICustomerService
{
    Task<bool> DeleteCustomerAsync(Guid cusomerId);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(Guid cusomerId);
}