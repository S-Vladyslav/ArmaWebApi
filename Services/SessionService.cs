using Domain;
using Repositories.Abstraction;
using Services.Abstraction;

namespace Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public SessionService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        private string _connectionString = "Data Source=localhost;Initial Catalog=ArmaGuidesDev;Integrated Security=True;Trust Server Certificate=true";

        public string GenerateNewSession(int userId)
        {
            var token = Guid.NewGuid().ToString();

            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.SessionRepository;

                var newSession = new Session
                {
                    UserId = userId,
                    Token = token
                };

                repo.Add(newSession);

                unitOfWork.Complete();
            }

            return token;
        }

        public bool CloseSessionByToken(string token)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.SessionRepository;

                var session = repo.GetSessionByToken(token);

                if (session != null)
                {
                    repo.Remove(session);

                    unitOfWork.Complete();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public Session GetSessionByToken(string token)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.SessionRepository;

                var session = repo.GetSessionByToken(token);

                return session;
            }
        }
    }
}
