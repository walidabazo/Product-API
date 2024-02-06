using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Interface
{
    public interface IGenericRepository <T> where T : BasicEntity<int>
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<T> GetByidAsync(int id, params Expression<Func<T, object>>[] includes);

        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        Task<T> GetAsync(int id);
        Task AddAsync(T Entity);
        Task DeleteAsync(int id);

        Task UpdateAsync(int id, T Entity);
        Task <int>CountAsync();
    }
}
