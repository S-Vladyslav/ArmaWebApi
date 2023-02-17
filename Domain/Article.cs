using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string IconUrl { get; set; }

        public string ArticleContent { get; set; }

        public string Category { get; set; }

        public int AuthorId { get; set; }

        public string PublishDate { get; set; }

        public virtual User Author { get; set; }
    }
}
