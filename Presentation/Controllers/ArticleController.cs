using System.Web.Mvc;
using Application.ApplicationService.Articles;
using Application.ApplicationService.Articles.Commands;
using Application.ApplicationService.Articles.Query;
using Presentation.Libs.Exceptions;
using Presentation.Models.Article;

namespace Presentation.Controllers {
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        
        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddConfirm(ArticleAddModel model)
        {
            var createArticle = new CreateArticleCommand(model.Title, model.Body, myId());
            articleService.CreateArticle(createArticle);

            // You shoud return generated id from service or defivary notification object, if you wanna redirect to detail.
            return RedirectToAction("MyList");
        }

        public ActionResult MyList()
        {
            var articles = articleService.GetByAuther(new ArticleGetByAutherQuery(myId()));
            var listViewModel = new ArticleListModel(articles);
            return View(listViewModel);
        }

        public ActionResult Detail(long? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("MyList");
            }
            var articleId = id.Value;
            var query = new ArticleGetDetailQuery(articleId);
            var detailResult = articleService.GetDetail(query);
            var optArticle = detailResult.Article;
            var article = optArticle.Match(
                x => new ArticleDto(x.Id, x.Title, x.Body),
                () => throw new TargetIdNotFoundException(articleId)
            );

            return View(article);
        }

        // Temporary implementation
        private long myId()
        {
            return 1;
        }
    }
}