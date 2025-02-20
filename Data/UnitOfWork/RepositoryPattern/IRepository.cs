using System.Linq.Expressions;

namespace Data.UnitOfWork.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null ,string includes = "");
        Task<T?> GetById(int id, string includes = "");
        Task Add(T entity);
        Task Add(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }

}
