using System.Linq;
using Application.ApplicationService.Articles;
using Application.ApplicationService.Articles.Commands;
using Application.ApplicationService.Articles.Query;
using Domain.Domain.Model.Articles;
using Domain.Domain.Model.Users;
using Domain.Library.Exceptions.Articles;
using MyLibrary.Options;

namespace Domain.Application.Articles {
    public class ArticleService : IArticleService {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public void CreateArticle(CreateArticleCommand command)
        {
            var autherId = new UserId(command.AutherId);
            var id = articleRepository.GenerateId();
            var article = new Article(id, command.Title, command.Body, autherId);
            articleRepository.Save(article);
        }

        public void Publish(PublishArticleCommand command)
        {
            var targetId = new ArticleId(command.AutherId);
            var targetArticleOpt = articleRepository.Find(targetId);
            targetArticleOpt.Match(
                article => article.Publish(),
                () => throw new ArticleCommandFailedException()
            );
        }

        public ArticleGetByAutherResultDto GetByAuther(ArticleGetByAutherQuery query)
        {
            var autherId = new UserId(query.AutherId);
            var articles = articleRepository.FindByAuther(autherId);
            var transformer = new ArticleToDtoTransformer();
            var articleDtos = articles.Select(x => x.Transform(transformer));
            var dto = new ArticleGetByAutherResultDto(articleDtos);
            return dto;
        }

        public ArticleDetailResultDto GetDetail(ArticleGetDetailQuery query)
        {
            var articleId = new ArticleId(query.ArticleId);
            var article = articleRepository.Find(articleId);
            var transformer = new ArticleToDtoTransformer();
            var dto = article.Match(x => Option<ArticleDto>.Create(x.Transform(transformer)), Option<ArticleDto>.None);
            return new ArticleDetailResultDto(dto);
        }
    }
}
