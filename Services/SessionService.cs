using Configuration;
using Domain;
using Repositories.Abstraction;
using Services.Abstraction;

namespace Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICustomConfigurationManager _configurationManager;

        public SessionService(IUnitOfWorkFactory unitOfWorkFactory, ICustomConfigurationManager configurationManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _configurationManager = configurationManager;
        }

        public async Task<string> GenerateNewSessionAsync(int userId)
        {
            var token = Guid.NewGuid().ToString();

            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.SessionRepository;

                var newSession = new Session
                {
                    UserId = userId,
                    Token = token
                };

                await repo.AddAsync(newSession);

                await unitOfWork.CompleteAsync();
            }

            return token;
        }

        public async Task CloseSessionAsync(Session session)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.SessionRepository;

                repo.Remove(session);

                await unitOfWork.CompleteAsync();
            }
        }

        public Session GetSessionByToken(string token)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.SessionRepository;

                var session = repo.GetSessionByToken(token);

                return session;
            }
        }
    }
}
