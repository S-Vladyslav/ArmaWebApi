namespace Domain.Users
{
    public class UserPublicInformation : BaseEntity
    {
        public string UserName { get; set; }

        public int UserRole { get; set; }

        public string CreationDate { get; set; }
    }
}
