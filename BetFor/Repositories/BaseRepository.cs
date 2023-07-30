using BetFor.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BetFor.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BetForBase
    {
        private readonly BetForContext dbContext;
        private DbSet<T> dbSet;

        public BaseRepository(BetForContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<bool> TryInsertItemAsync(T item)
        {
            await dbSet.AddAsync(item);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> TryInsertListAsync(ICollection<T> itemList)
        {
            await dbSet.AddRangeAsync(itemList);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> TryUpdateItemAsync(T item)
        {
            dbContext.Entry<T>(item).State = EntityState.Detached;
            dbContext.Set<T>().Update(item);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> TryUpdateListAsync(ICollection<T> itemList)
        {
            dbSet.UpdateRange(itemList);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> TryDeleteItemAsync(T item)
        {
            dbSet.Remove(item);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> TryDeleteListAsync(ICollection<T> itemList)
        {
            dbSet.RemoveRange(itemList);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate, params string[] includeProps)
        {
            IQueryable<T> query = dbSet;
            if (includeProps != null && includeProps.Length > 0)
            {
                foreach (var item in includeProps)
                {
                    query = query.Include(item);
                }
            }

            var result = await query.FirstOrDefaultAsync(predicate);

            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<IQueryable<T>> GetFilteredItemsAsync(Expression<Func<T, bool>> predicate, params string[] includeProps)
        {
            IQueryable<T> query = dbSet;
            if (includeProps != null && includeProps.Length > 0)
            {
                foreach (var item in includeProps)
                {
                    query = query.Include(item);
                }
            }

            return await Task.FromResult(query.Where(predicate));
        }
    }
}