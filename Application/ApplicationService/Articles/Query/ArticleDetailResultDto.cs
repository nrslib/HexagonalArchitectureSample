using MyLibrary.Options;

namespace Application.ApplicationService.Articles.Query {
    public class ArticleDetailResultDto {
        public ArticleDetailResultDto(Option<ArticleDto> article)
        {
            Article = article;
        }

        public Option<ArticleDto> Article { get; }
    }
}
