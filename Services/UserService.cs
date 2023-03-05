using Domain.Users;
using Repositories.Abstraction;
using Services.Abstraction;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UserService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        private string _connectionString = "Data Source=localhost;Initial Catalog=ArmaGuidesDev;Integrated Security=True;Trust Server Certificate=true";

        public UserPrivateInformation GetUserPrivateInformationById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = repo.Get(id);

                var userInfo = new UserPrivateInformation
                {
                    Id = id,
                    UserName = user.UserName,
                    Email = user.Email,
                    UserRole = user.UserRole,
                    CreationDate = user.CreationDate
                };

                return userInfo;
            }
        }

        public UserPublicInformation GetUserPublicInformationById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = repo.Get(id);

                var userInfo = new UserPublicInformation
                {
                    Id = id,
                    UserName = user.UserName,
                    UserRole = user.UserRole,
                    CreationDate = user.CreationDate
                };

                return userInfo;
            }
        }

        public User GetUserById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = repo.Get(id);

                return user;
            }
        }

        public void AddNewUser(User user)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.UserRepository;

                repo.Add(user);

                unitOfWork.Complete();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = repo.GetUserByEmail(email);

                return user;
            }
        }
    }
}
