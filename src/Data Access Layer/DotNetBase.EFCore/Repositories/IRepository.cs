using System.Linq.Expressions;

namespace DotNetBase.EFCore.Repositories
{
    // Core/Interfaces/IRepository.cs
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity); // Dikkat: Asenkron olmayan Update ve Remove
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
