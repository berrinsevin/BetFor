using System.Linq.Expressions;

namespace BetFor.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<bool> TryInsertItemAsync(T item);
        Task<bool> TryInsertListAsync(ICollection<T> itemList);
        Task<bool> TryUpdateItemAsync(T item);
        Task<bool> TryUpdateListAsync(ICollection<T> itemList);
        Task<bool> TryDeleteItemAsync(T item);
        Task<bool> TryDeleteListAsync(ICollection<T> itemList);
        Task<T> GetItemAsync(Expression<Func<T, bool>> predicate, params string[] includeProps);
        Task<IQueryable<T>> GetFilteredItemsAsync(Expression<Func<T, bool>> predicate, params string[] includeProps);
    }
}