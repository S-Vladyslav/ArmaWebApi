using Repositories.Abstraction;
using Repositories.Context;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDBContext AppDBContext;

        public Repository(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public TEntity Get(int id)
        {
            return AppDBContext.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            AppDBContext.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            AppDBContext.Set<TEntity>().Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return AppDBContext.Set<TEntity>().Select(x => x).ToList();
        }
    }
}
