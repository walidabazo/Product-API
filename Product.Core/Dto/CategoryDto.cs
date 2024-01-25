using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data
{
    public class CategoryDto
    {
        [Required]
       // public int id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
    }
    public class ListCategoryDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
