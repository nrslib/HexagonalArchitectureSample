using System.Linq;
using Application.ApplicationService.Articles.Query;

namespace Presentation.Models.Article {
    public class ArticleListModel {
        public ArticleListModel(ArticleGetByAutherResultDto source)
        {
            Rows = source.Articles.Select(x => new ArticleListRow(x)).ToArray();
        }

        public ArticleListRow[] Rows { get; }
    }

    public class ArticleListRow
    {
        public ArticleListRow(ArticleDto source)
        {
            Id = source.Id;
            Title = source.Title;
        }

        public long Id { get; }
        public string Title { get; }
    }
}