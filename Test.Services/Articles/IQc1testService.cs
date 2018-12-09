using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Services.Articles.Dto;

namespace Test.Services.Articles
{
    public interface IQc1testService: IHttpApiServiceBase
    {
        Task<IEnumerable<ArticleDto>> GetCatalogItems();
        Task LoadArticles();
    }
}