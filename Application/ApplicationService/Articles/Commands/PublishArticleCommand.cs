namespace Application.ApplicationService.Articles.Commands {
    public class PublishArticleCommand {
        public PublishArticleCommand(long autherId)
        {
            AutherId = autherId;
        }

        public long AutherId { get; }
    }
}
