using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.UnitOfWork.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string includes = "")
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includes))
            {
                foreach (string include in includes.Split(","))
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(filter);
        }
        public async Task<IEnumerable<T>> GetAll(string includes = "")
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includes))
            {
                foreach (string include in includes.Split(","))
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }
        public async Task<T?> GetById(int id, string includes = "")
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includes))
            {
                foreach (string include in includes.Split(","))
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
        public async Task Add(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
    }

}
