using Domain.Users;

namespace Services.Abstraction
{
    public interface IUserService
    {
        Task<UserPrivateInformation> GetUserPrivateInformationByIdAsync(int id);

        Task<UserPublicInformation> GetUserPublicInformationByIdAsync(int id);

        Task AddNewUserAsync(User user);

        User GetUserByEmail(string email);

        Task<User> GetUserByIdAsync(int id);
    }
}
