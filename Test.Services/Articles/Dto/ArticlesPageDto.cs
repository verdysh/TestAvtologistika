using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.Articles.Dto
{
    public class ArticlesPageDto
    {
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public IEnumerable<ArticleDto> Articles { get; set; }
    }
}

