using AutoMapper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Services.Articles.Dto;

namespace Test.Services.Articles
{
    public class ArticleService: ServiceBase, IArticleService
    {
        public ArticlesPageDto GetPage(int articlesOnPage, int page)
        {
            if(articlesOnPage < 1)
                throw new ArgumentException();

            if (page < 1)
                throw new ArgumentException();

            int articlesCount = _unitOfWork.ArticlesRepository.Get(a => !a.IsFolder).Count();

            ArticlesPageDto articlesPage = new ArticlesPageDto();
            articlesPage.Pages = articlesCount / articlesOnPage;
            articlesPage.CurrentPage = page > articlesPage.Pages ? articlesPage.Pages : page;

            articlesPage.Articles = Mapper.Map<IEnumerable<ArticleDto>>(
                _unitOfWork.ArticlesRepository
                .Get(
                    filter: a => !a.IsFolder, 
                    pageSize: articlesOnPage, 
                    page: articlesPage.CurrentPage
                )
                .ToList());

            return articlesPage;
        }

        public ArticleDto GetByTitleId(string titleId)
        {
            return Mapper.Map<ArticleDto>(
                _unitOfWork.ArticlesRepository.Get(a => a.TitleId == titleId).FirstOrDefault()
            );
        }
    }
}
