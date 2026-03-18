using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Dto
{
    public class CreateProductDto
    {
        [Required]
        public  string Name { get; set; }=string.Empty;

        [Required]
        public  string Description { get; set; }= string.Empty;

       [Range(0.01,double.MaxValue,ErrorMessage ="price must be greater than 0")]

        public decimal Price { get; set; }

        [Required]
        public  string PictureUrl { get; set; }=string.Empty ;
        [Required]
        public  string Type { get; set; } = string.Empty ;
        [Required]
        public  string Brand { get; set; } =string.Empty ;

        [Range(0.01,int.MaxValue,ErrorMessage ="Product in stock must be atleat one")]
        public int ProductinStock { get; set; }
    }
}
