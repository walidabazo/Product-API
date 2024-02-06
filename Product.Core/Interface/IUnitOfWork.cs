using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Interface
{
    public interface IUnitOfWork
    {
        public IcategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IBasketRepository BasketRepository { get; }
    }
}
