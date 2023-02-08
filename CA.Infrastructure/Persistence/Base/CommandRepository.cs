using Microsoft.EntityFrameworkCore;
using CA.Infrastructure.DataContext;
using CA.Application.Common.Interfaces.Persistence;
using CA.Application.Common.Interfaces.Persistence.Base;

namespace CA.Infrastructure.Persistence.Base;
public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly EfCoreContext _context;

        public CommandRepository(EfCoreContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }