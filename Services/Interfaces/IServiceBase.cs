namespace TCC_API.Services.Interfaces
{
    public interface IServiceBase<T> where T : Models.Database.BaseTable
    {
        Task<IEnumerable<T>> Get();

        Task<T> GetById(long id);

        Task<T> Create(T model);

        Task<T> Update(T model);

        Task<bool> Delete(long id);
    }
}
