namespace TCC_API.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : Models.Database.BaseTable
    {
        public List<T> Get();

        public T GetById(long id);

        public T Create(T model);

        public T Update(T model);

        public bool Delete(long id);
    }
}
