using ApiWithJWT.Dtos.Carts;
using ApiWithJWT.Dtos.Ordrers;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Users
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
         public  string UserName { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;
       
        public List<OrderDto> Orders { get; set; }

    }
}
