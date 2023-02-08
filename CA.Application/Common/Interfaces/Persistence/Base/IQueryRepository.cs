namespace CA.Application.Common.Interfaces.Persistence.Base;
 public interface IQueryRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(T entity);
        Task<T> GetByIdAsync(T entity);
        Task<T> GetByEmail(T entity);
    }