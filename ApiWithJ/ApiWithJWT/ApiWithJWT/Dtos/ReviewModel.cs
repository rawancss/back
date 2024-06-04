using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiWithJWT.Models;

namespace ApiWithJWT.Dtos
{
    public class ReviewModel
    {
        [Key]
        [Required]
        public Guid ReviewId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int Rating { get; set; }

        public required string Comment { get; set; }

        [ForeignKey("ProductId")]
        public required Product Product { get; set; }

        [ForeignKey("UserId")]
        public required Account User { get; set; }


    }
}