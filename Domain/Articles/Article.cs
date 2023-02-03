namespace Domain.Articles
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string IconUrl { get; set; }

        public List<ArticleContent> ArticleContents { get; set; }
    }
}
