using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiWithJWT.Models;

namespace ApiWithJWT.Dtos

{
    public class PaymentModel
    {
        [Key]
        [Required]
        public Guid PaymentId { get; set; }

        public int OrderId { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [MaxLength(50)]
        public required string PaymentMethod { get; set; }

        [ForeignKey("OrderId")]
        public required Order Order { get; set; }
    }

}