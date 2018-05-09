namespace Application.ApplicationService.Articles.Commands {
    public class CreateArticleCommand {
        public CreateArticleCommand(string title, string body, long autherId)
        {
            Title = title;
            Body = body;
            AutherId = autherId;
        }

        public string Title { get; }
        public string Body { get; }
        public long AutherId { get; }
    }
}
