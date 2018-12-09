using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test.Services.Articles;

namespace Test.Web.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService;

        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ActionResult> Index(int page = 1)
        {
            if (page < 1)
                page = 1;

            if(!User.Identity.IsAuthenticated)
                return View("Page403");

            var articles = _articleService.GetPage(Int32.Parse(ConfigurationManager.AppSettings["articlesOnPage"]), page);
            return View(articles);
                
        }

        public ActionResult Article(string id)
        {
            var article = _articleService.GetByTitleId(id);
            if (article == null)
                return View("Page404");

            return View(article);
        }
    }
}