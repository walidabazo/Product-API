using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Entities
{
    public class Category: BasicEntity<int>
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Products> Products { get; set; } = new HashSet<Products>();

        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

    }
}
