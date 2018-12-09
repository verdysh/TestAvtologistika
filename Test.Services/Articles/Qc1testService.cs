using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Test.Data.Entities;
using Test.Services.Articles.Dto;

namespace Test.Services.Articles
{
    public class Qc1testService: HttpApiServiceBase, IQc1testService
    {
        public Qc1testService(string url, double timeOut = 0): base(url, timeOut) { }

        public async Task<IEnumerable<ArticleDto>> GetCatalogItems()
        {
            var json = await Get("GetCatalogItems");
            return JsonConvert.DeserializeObject<List<ArticleDto>>(json);
        }

        public async Task LoadArticles()
        {
            var articles = await GetCatalogItems();
            var apiIds = articles.Select(aa => aa.ApiId);

            var existApiIds =_unitOfWork.ArticlesRepository.Get(a => apiIds.Contains(a.ApiId)).Select(r => r.ApiId);
            articles = articles.Where(a => !existApiIds.Contains(a.ApiId));
            if (articles.Count() == 0)
                return;

            foreach (var article in articles)
            {
                string TitleId = Regex.Replace(article.Title, @"[^a-zA-Zа-яА-Я\d ]+", "");
                TitleId = Regex.Replace(TitleId, " {1,}", "-");
                var articleDb = Mapper.Map<Article>(article);
                articleDb.TitleId = $"{TitleId}-{article.ApiId}";
                _unitOfWork.ArticlesRepository.Insert(articleDb);
            }

            _unitOfWork.Save();
        }
    }
}
