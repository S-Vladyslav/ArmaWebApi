namespace Services.Abstraction
{
    public interface ISessionService
    {
        string GenerateNewSession(int userId);
    }
}
