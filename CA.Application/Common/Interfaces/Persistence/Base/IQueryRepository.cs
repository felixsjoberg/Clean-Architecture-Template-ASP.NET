namespace CA.Application.Common.Interfaces.Persistence.Base;
 public interface IQueryRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByEmail(string email);
    }