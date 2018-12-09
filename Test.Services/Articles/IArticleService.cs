using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Services.Articles.Dto;

namespace Test.Services.Articles
{
    public interface IArticleService
    {
        ArticlesPageDto GetPage(int count, int offset);
        ArticleDto GetByTitleId(string titleId);
    }
}
