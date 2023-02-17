namespace Repositories.Abstraction
{
    public interface IRepository <TEntity> where TEntity : class
    {
        TEntity Get(int id);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        List<TEntity> GetAll();
    }
}
