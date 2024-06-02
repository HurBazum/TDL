namespace TDL.Interfaces
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        Task<IResponse<T>> CreateAsync(T entity);
        Task<IResponse<T>> UpdateAsync(T entity);
        Task<IResponse<T>> DeleteAsync(T entity);
        Task<IResponse<List<T>>> GetAllAsync();
        Task<List<T>> GetAll();
        Task<IResponse<T>> GetByIdAsync(int id);
    }
}