using System.Linq.Expressions;

namespace dotnetAPI_footballTeam.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int currentPage = 0);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
