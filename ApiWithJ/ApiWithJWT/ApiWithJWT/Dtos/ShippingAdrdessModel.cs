using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiWithJWT.Models;

namespace ApiWithJWT.Dtos
{

    public class ShippingAddressModel
    {
        [Key]
        [Required]
        public Guid AddressId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [MaxLength(100)]
        public string AddressLine1 { get; set; } = string.Empty;
        public required string City { get; set; }

        [MaxLength(50)]
        public required string State { get; set; }
        [MaxLength(50)]
        public required string Country { get; set; }

        [ForeignKey("UserId")]
        public required Account User { get; set; }
    }
}