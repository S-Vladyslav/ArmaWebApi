using Domain;
using Repositories.Abstraction;
using Repositories.Context;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDBContext AppDBContext;

        public Repository(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await AppDBContext.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await AppDBContext.Set<TEntity>().AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            AppDBContext.Set<TEntity>().Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return AppDBContext.Set<TEntity>().Select(x => x).ToList();
        }

        public List<TEntity> GetPage(int pageSize, int start)
        {
            return AppDBContext.Set<TEntity>()
                .Skip(start)
                .Take(pageSize)
                .ToList();
        }
    }
}
