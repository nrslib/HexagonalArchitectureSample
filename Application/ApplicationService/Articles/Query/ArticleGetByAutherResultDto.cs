using System.Collections.Generic;
using System.Linq;

namespace Application.ApplicationService.Articles.Query {
    public class ArticleGetByAutherResultDto {
        public ArticleGetByAutherResultDto(
            IEnumerable<ArticleDto> articles
            )
        {
            Articles = articles.ToArray();
        }

        public ArticleDto[] Articles { get; }
    }
}
