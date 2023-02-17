using Repositories.Abstraction.UnitOfWorks;

namespace Repositories.Abstraction
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork(string connectionString);
    }
}
