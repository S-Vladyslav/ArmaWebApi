namespace Domain.Users
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public int UserRole { get; set; }

        public string CreationDate { get; set; }
    } 
}
