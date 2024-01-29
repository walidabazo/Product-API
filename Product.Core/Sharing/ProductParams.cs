using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Sharing
{
    public class ProductParams
    {
    

        //public int PageSize
        //{
        //    get { return _pageSize; }
        //    set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        //}

        //public int PageNumber { get; set; } = 1;
        //public string Sort { get; set; }
        //public int? CategoryId { get; set; }

        //private string _search;

        //public string Search
        //{
        //    get { return _search; }
        //    set { _search = value.ToLower(); }
        //}


        //Page size
        public int maxpagesize { get; set; } = 5;
        private int pagesize = 3;
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

    }
}
