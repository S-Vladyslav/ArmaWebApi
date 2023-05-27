namespace Repositories.Abstraction
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        List<TEntity> GetAll();

        List<TEntity> GetPage(int pageSize, int start);
    }
}
