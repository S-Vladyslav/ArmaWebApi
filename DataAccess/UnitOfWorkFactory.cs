using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
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
