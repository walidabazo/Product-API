//Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1
using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Interface;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Product.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BasicEntity<int>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        public async Task AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()

         => _context.Set<T>().AsNoTracking().ToList();

        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);

            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
     => await _context.Set<T>().FindAsync(id);
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        public async Task<T> GetByidAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            //  IQueryable<T> query = _context.Set<T>();
            IQueryable<T> query = _context.Set<T>().Where(x => x.Id == id);
            foreach (var item in includes)
            {
                query = query.Include(item);

            }
            return await query.FirstOrDefaultAsync();
          //  return await ((DbSet<T>)query).FindAsync();

        }
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        public async Task UpdateAsync(int id, T Entity)
        {
            var ex_entity = await _context.Set<T>().FindAsync(id);
            if (ex_entity != null)
            {
                _context.Update(ex_entity);
                await _context.SaveChangesAsync();
            }
        }

       public async Task<int> CountAsync()
        =>await _context.Set<T>().CountAsync();
    }
}
