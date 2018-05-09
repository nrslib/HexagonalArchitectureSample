using Application.ApplicationService.Articles.Commands;
using Application.ApplicationService.Articles.Query;

namespace Application.ApplicationService.Articles {
    public interface IArticleService {
        void CreateArticle(CreateArticleCommand command);
        void Publish(PublishArticleCommand command);
        ArticleGetByAutherResultDto GetByAuther(ArticleGetByAutherQuery query);
        ArticleDetailResultDto GetDetail(ArticleGetDetailQuery query);
    }
}
