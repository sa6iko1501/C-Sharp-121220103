using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application3
{
    /*
     * Отговорът на заявката първоначално е 200 ОК, но после може да бъде error с RateLimited. Това е тъй като изпращаме директна заявка без код за ауторизация
     * програматично, което ipapi възприема за suspicious activity.
     */
 class IpAdressService
    {
        private HttpClient _httpClient;

        public IpAdressService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetCountry(string ipAdress)
        {
            try
            {
                string endpointUrlWithPathVariable = "https://ipapi.co/" + ipAdress + "/country/";
                HttpResponseMessage response = await _httpClient.GetAsync(endpointUrlWithPathVariable);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Failed to recieve a country";
                }
            }
            catch(Exception ex) 
            {
                throw new Exception("Error occurred :" + ex.Message.ToString());
            }
        }
    }
}
