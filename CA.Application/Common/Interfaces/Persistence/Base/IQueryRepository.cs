namespace CA.Application.Common.Interfaces.Persistence.Base;
 public interface IQueryRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        // Depending on db change guid to int.
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByEmail(string email);
    }