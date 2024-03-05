using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Application3
{
    /*
     * Тък няма какво толкова да напиша като коментар. Стандартна GET заявка и парсване на HTML файл.
     */
class DateAndTimeService
    {
        private string url = "https://www.timeanddate.com/worldclock/bulgaria/sofia";
        public async Task<String> getCurrentDateAndTime()
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string htmlContent = await response.Content.ReadAsStringAsync();

                // HtmlDocument е клас от HtmlAgilityPack библиотеката, която се използва за обработка на HTML документ в .NET проекти
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(htmlContent);
                HtmlNode currTimeNode = html.DocumentNode.SelectSingleNode("//span[@id='ct']");
                HtmlNode currDateNode = html.DocumentNode.SelectSingleNode("//span[@id='ctdat']");
                if(currTimeNode != null && currDateNode != null) {
                    string currDateAndTime = currTimeNode.InnerText.Trim() + " " + currDateNode.InnerText.Trim();
                    return currDateAndTime;
                }
                else
                {
                    throw new Exception("Failed to retrieve current date and time");
                }
            }
        }
    }
}
