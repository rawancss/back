using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiWithJWT.Models;

namespace ApiWithJWT.Dtos
{


    public class OrderItemModel
    {
        [Key]
        [Required]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

 
        public decimal Price { get; set; }

        public  Order Order { get; set; }

        public  Product Product { get; set; }
    }
}