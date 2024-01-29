using Product.Core.Entities;
using Product.Core.Sharing;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Interface
{
    public interface IProductRepository : IGenericRepository<Products>
    {

       // Task<IEnumerable<ProductDto>> GetAllAsync(ProductParams productParams);
        Task<ReturnProductDto> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
