using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _appDbContext;

        public IArticleRepository ArticleRepository { get; private set; }

        public UnitOfWork(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;

            ArticleRepository = new ArticleRepository(_appDbContext);
        }

        public int Complete()
        {
            return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
