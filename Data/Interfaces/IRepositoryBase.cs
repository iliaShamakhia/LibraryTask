namespace Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task Create(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}
