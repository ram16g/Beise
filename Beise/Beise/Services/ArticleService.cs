using Beise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Beise.Services
{
    public class ArticleService : IArticleService
    {

        HttpClient httpClient;
        JsonSerializerOptions serializerOptions;

        public ArticleListResult Article { get; private set; }

        public ArticleService()
        {
            httpClient = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                MaxDepth = 0
            };
        }
        
        
        public async Task<ArticleListResult> GetArticles()
        {
            Article = new ArticleListResult();

            Uri uri = new Uri("https://www.beise.com/index.php?m=app&c=home&a=news");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //ArticleListResult = JsonSerializer.Deserialize<ArticleListResult>(content, serializerOptions);

                    Article =  Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleListResult>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Article;
        }
    }
}
