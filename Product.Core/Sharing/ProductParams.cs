//Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Sharing
{
    public class ProductParams
    {
    

        //Page size
        public int maxpagesize { get; set; } = 50;
        private int pagesize = 13;
       public int Pagesize {
            get => pagesize;
            set => pagesize = value > maxpagesize ? maxpagesize : value;
                }
        public int PageNumber { get; set; } = 1;

        //Filter By Category
        public int? Categoryid { get; set; }
        //Sorting
        public string Sorting { get; set; }
        //search 

        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

    }
}
