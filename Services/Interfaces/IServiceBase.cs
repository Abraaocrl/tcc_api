namespace TCC_API.Services.Interfaces
{
    public interface IServiceBase<T> where T : Models.Database.BaseTable
    {
        public Task<IEnumerable<T>> Get();

        public Task<T> GetById(long id);

        public Task<T> Create(T model);

        public Task<T> Update(T model);

        public Task<bool> Delete(long id);
    }
}
