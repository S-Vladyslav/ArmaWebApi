﻿namespace Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string CreationDate { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    } 
}
