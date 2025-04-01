namespace Domain.Services
{
    public interface IDataService<T>
    {
        Task <IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T item);
        Task<T> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);

    }
}