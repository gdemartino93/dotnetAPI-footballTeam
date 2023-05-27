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
        public void Add(T entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange();
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
