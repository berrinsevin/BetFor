using BetFor.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BetFor.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BetForBase
    {
        private readonly BetForContext _dbContext;
        private DbSet<T> _dbSet;

        public BaseRepository(BetForContext dbContext)
        {
            _dbContext = dbContext; _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
        public T GetById(long id)
        {
            var data = _dbSet.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                return data;
            }

            return null;
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}