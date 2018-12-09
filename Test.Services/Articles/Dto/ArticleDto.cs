using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test.Services.Articles.Dto
{
    public class ArticleDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonProperty("id")]
        public int ApiId { get; set; }

        public bool IsFolder { get; set; }

        public int RowVer { get; set; }

        public string Title { get; set; }
        public string TitleId { get; set; }

        public string Body { get; set; }

        public string Preview
        {
            get
            {
                var regex = new Regex(@"<p>(.*?)</p>");
                if (regex.IsMatch(Body))
                {
                    Match match = regex.Match(Body);
                    return match.Groups[0].Value;
                }
                else
                    return "No preview";
            }
        }

        public DateTime Date { get; set; }
    }
}