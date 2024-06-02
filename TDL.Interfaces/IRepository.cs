namespace TDL.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> CreateAsync(T entity);
    }
}