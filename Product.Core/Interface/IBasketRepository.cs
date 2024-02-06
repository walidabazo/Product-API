using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Interface
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketid);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
        Task<bool> DeleteBasketAsync(string basketid);

    }
}
