namespace Domain.Interfaces.Common
{
    public interface ICommon<T> where T : class
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> SelectById(int id);
        Task<List<T>> SelectAll();
    }
}
