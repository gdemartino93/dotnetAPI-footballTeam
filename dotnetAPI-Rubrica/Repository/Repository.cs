using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace dotnetAPI_footballTeam.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> dbSet;
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int currentPage = 0)
        {
            IQueryable<T> query = dbSet;
            if(filter is not null)
            {
                query = query.Where(filter);
            }
            if (includeProperties is not null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if(pageSize > 0)
            {
                if(currentPage == 0)
                {
                    currentPage = 1;
                }
                query = query.Skip(pageSize * (currentPage - 1)).Take(pageSize);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filter is not null)
            {
                query = query.Where(filter);
            }
            if (includeProperties is not null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            dbSet.Add(entity);
            await SaveAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public Task SaveAsync()
        {
            return _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
