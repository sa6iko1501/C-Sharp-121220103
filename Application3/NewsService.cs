using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Application3
{
    /*
     * По задание трябва да търсим всички новини, които не съдържат "Covid-19" или "Пандемия", но тъй като вече не е 2020 съм сменил ключовите думи с "Украйна" и "Зеленски". И така
     * нашата апликация ще сортира и публикува само тези новини, които не съдържат "Украйна" или "Зеленски" в себе си. Отново ползваме библиотеката HtmlAgilityPack
     */
class NewsService
    {
        private string url = "https://www.mediapool.bg";
        public async Task<List<string>> GetArticleSummaries()
        {
            List<string> summaries = new List<string>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string htmlContent = await response.Content.ReadAsStringAsync();
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(htmlContent);
                HtmlNodeCollection summaryNodes = html.DocumentNode.SelectNodes("//li[contains(@class, 'l-grid__cell')]//h3");
                if(summaryNodes != null)
                {
                    foreach(HtmlNode summaryNode in summaryNodes)
                    {
                        string summary = summaryNode.InnerText;
                        if (!summary.Contains("Украйна") && !summary.Contains("Зеленски"))
                        {
                            summaries.Add(summary);
                        }
                    }
                    return summaries;
                }
                else
                {
                    throw new Exception("Failed to fetch news articles");
                }
            }
        }
    }
}
