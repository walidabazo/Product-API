using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Interface
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] includes);

        Task<T> GetByidAsync(T id, params Expression<Func<T, bool>>[] includes);


        Task<T> GetAsync(int id);
        Task AddAsync(T Entity);
        Task DeleteAsync(int id);

        Task UpdateAsync(int id, T Entity);
    }
}
