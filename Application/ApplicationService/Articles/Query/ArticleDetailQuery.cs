namespace Application.ApplicationService.Articles.Query {
    public class ArticleGetDetailQuery {
        public ArticleGetDetailQuery(long articleId)
        {
            ArticleId = articleId;
        }

        public long ArticleId { get; }
    }
}
