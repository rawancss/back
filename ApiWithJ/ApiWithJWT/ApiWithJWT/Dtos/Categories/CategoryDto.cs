
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Categories

{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public  string Name { get; set; }
   }
}
