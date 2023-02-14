using DataAccess.UnitOfWorks;

namespace DataAccess
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork(string connectionString);
    }
}
