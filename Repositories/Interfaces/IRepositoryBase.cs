namespace TCC_API.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : Models.Database.BaseTable
    {
        public Task<List<T>> Get();

        public Task<T> GetById(long id);

        public Task<T> Create(T model);

        public Task<T> Update(T model);

        public Task<bool> Delete(long id);
    }
}
