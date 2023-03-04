using Domain.Users;

namespace Services.Abstraction
{
    public interface IUserService
    {
        UserPrivateInformation GetUserPrivateInformationById(int id);

        UserPublicInformation GetUserPublicInformationById(int id);

        void AddNewUser(User user);

        User GetUserByEmail(string email);
    }
}
