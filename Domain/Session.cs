namespace Domain
{
    public class Session : BaseEntity
    {
        public int UserId { get; set; }

        public string Token { get; set; }
    }
}
