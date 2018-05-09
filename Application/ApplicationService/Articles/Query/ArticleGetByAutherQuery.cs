namespace Application.ApplicationService.Articles.Query {
    public class ArticleGetByAutherQuery {
        public ArticleGetByAutherQuery(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
