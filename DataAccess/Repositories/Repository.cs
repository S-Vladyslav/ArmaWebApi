﻿using DataAccess.Interfaces;

namespace DataAccess.Repositories
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
    }
}