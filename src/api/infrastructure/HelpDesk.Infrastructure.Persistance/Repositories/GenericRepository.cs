using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Api.Domain.Models;
using HelpDesk.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;

        public GenericRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = context.Set<T>().Find(id);
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {

            return filter == null ? context.Set<T>().AsNoTracking() : context.Set<T>().Where(filter).AsNoTracking();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public virtual IQueryable<T> AsQueryable() => context.Set<T>().AsQueryable();

    }
}
