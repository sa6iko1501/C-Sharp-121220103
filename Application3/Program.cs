
using Application3;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Hello!\n");
Console.WriteLine("1. See country of origin of IP adress");
Console.WriteLine("2. See current date and time in Sofia");
Console.WriteLine("3. See current news not containing information regarding Ukraine");
String input = Console.ReadLine();
switch (input)
{
    case "1":
        {
            Console.WriteLine("Input IP:\n");
            string ipAddress = Console.ReadLine();  
            IpAdressService adressService = new IpAdressService();
            try
            {
                string country = await adressService.GetCountry(ipAddress);
                Console.WriteLine("Country of origin is: " + country);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        }
    case "2":
        {
            try
            {
                DateAndTimeService dateAndTimeService = new DateAndTimeService();
                string currDateAndtime = await dateAndTimeService.getCurrentDateAndTime();
                Console.WriteLine("Current date and time in Sofia: " + currDateAndtime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        }
    case "3":
        {
            NewsService newsService = new NewsService();
            try
            {
                List<string> articles = await newsService.GetArticleSummaries();
                foreach (string article in articles) 
                {
                    Console.WriteLine("\t" + article);
                    Console.WriteLine("\t_________________________________________________________\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        }
    default:
        {
            Console.WriteLine("Bad Choice ;)");
            break;
        }
}