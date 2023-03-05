using Domain;

namespace Services.Abstraction
{
    public interface ISessionService
    {
        string GenerateNewSession(int userId);

        void CloseSession(Session session)

        Session GetSessionByToken(string token);
    }
}
