using Configuration;
using Domain.Users;
using Repositories.Abstraction;
using Services.Abstraction;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICustomConfigurationManager _configurationManager;

        public UserService(IUnitOfWorkFactory unitOfWorkFactory, ICustomConfigurationManager configurationManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _configurationManager = configurationManager;
        }

        public async Task<UserPrivateInformation> GetUserPrivateInformationByIdAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = await repo.GetAsync(id);

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

        public async Task<UserPublicInformation> GetUserPublicInformationByIdAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = await repo.GetAsync(id);

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

        public async Task<User> GetUserByIdAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = await repo.GetAsync(id);

                return user;
            }
        }

        public async Task AddNewUserAsync(User user)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.UserRepository;

                await repo.AddAsync(user);

                await unitOfWork.CompleteAsync();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.UserRepository;

                var user = repo.GetUserByEmail(email);

                return user;
            }
        }
    }
}
