namespace Domain.Users
{
    public class UserPrivateInformation : BaseEntity
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public int UserRole { get; set; }

        public string CreationDate { get; set; }
    }
}
