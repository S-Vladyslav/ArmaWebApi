using DataAccess;
using DataAccess.Context;
using DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Repositories.UnitOfWorks
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork GetUnitOfWork(string connectionString)
        {
            var context = CreateDbContext(connectionString);
            var unitOfWork = new UnitOfWork(context);

            return unitOfWork;
        }

        private AppDBContext CreateDbContext(string connectionString)
        {
            var contextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new AppDBContext(contextOptions);
        }
    }
}
