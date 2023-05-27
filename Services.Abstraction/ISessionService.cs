using Domain;

namespace Services.Abstraction
{
    public interface ISessionService
    {
        Task<string> GenerateNewSessionAsync(int userId);

        Task CloseSessionAsync(Session session);

        Session GetSessionByToken(string token);
    }
}
