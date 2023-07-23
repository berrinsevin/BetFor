using System.Linq.Expressions;

namespace BetFor.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T entitiy);
        void Update(T entitiy);
        void Delete(T entitiy);
        IEnumerable<T> GetAll();
        T GetById(long id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}