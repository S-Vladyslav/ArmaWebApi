﻿namespace Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public string CreationDate { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    } 
}
