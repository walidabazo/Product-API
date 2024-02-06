//Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data
{
    public class BaseProduct
    {
       [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Range(1,9999,ErrorMessage ="Price Limited By {0} and {1}") ]
        [RegularExpression(@"[0-9]*\.?[0-9]+",ErrorMessage ="{0} Must be Number !")]
        public decimal Price { get; set; }
    }
    //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

    public class ProductDto : BaseProduct
    {

        public int Id { get; set; }

        public string CategoryName { get; set; }
        public string ProductPicture { get; set; }
    }
    public class ReturnProductDto
    {
        public int TotalItems { get; set; }
        public List<ProductDto> ProductDtos { get; set; }
    }
    public class CreateProductDto : BaseProduct 
    {
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
    //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

    //Update Product
    public class UpdateProductDto : BaseProduct
    {
     
            public int CategoryId { get; set; }
          public string OldImage { get; set; }
            public IFormFile Image { get; set; }
       
    }

}
