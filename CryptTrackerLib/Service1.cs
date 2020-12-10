using System;
using System.Net;
using System.Text.Json;
using System.Web;

namespace CryptTrackerLib
{
    public class Service1 : IService1
    {
        private static string API_KEY = "be39bd63-d630-446c-8b1f-dd243fda85cc";

        public string Parse(string s)
        {
            string input = s.Trim().ToLower();

            if (input == "getbtc")
            {

                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["start"] = "1";
                queryString["limit"] = "1";
                queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                client.Headers.Add("Accepts", "application/json");

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(client.DownloadString(URL.ToString()));

                var outPut = JsonSerializer.Serialize(jsonElement, options);

                Console.WriteLine("Received Input({0})", input);
                Console.WriteLine("Return {0}", outPut);

                return JsonSerializer.Serialize(jsonElement, options);

            }
            else if (input == "getBTC")
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                
                queryString["symbol"] = "BTC";
                queryString["limit"] = "5";
                queryString["sort"] = "id";
                queryString["symbol"] = "BTC";
                

                //queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                client.Headers.Add("Accepts", "application/json");

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(client.DownloadString(URL.ToString()));
                var outPut = JsonSerializer.Serialize(jsonElement, options);

                Console.WriteLine();
                Console.WriteLine("Parse{0}" , outPut);

                return JsonSerializer.Serialize(jsonElement, options);

            }
            else if (input == "geteth")
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["listing_status"] = "active";
                queryString["start"] = "1";
                queryString["limit"] = "5";
                queryString["sort"] = "id";
                queryString["symbol"] = "ETH";
                queryString["aux"] = "platform,first_historical_data,last_historical_data,is_active";

                //queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                client.Headers.Add("Accepts", "application/json");

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(client.DownloadString(URL.ToString()));

                Console.WriteLine(jsonElement);

                return JsonSerializer.Serialize(jsonElement, options);

            }
            else if (input == "getXRP")
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["listing_status"] = "active";
                queryString["start"] = "1";
                queryString["limit"] = "5";
                queryString["sort"] = "id";
                queryString["symbol"] = "XRP";
                queryString["aux"] = "platform,first_historical_data,last_historical_data,is_active";

                //queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                client.Headers.Add("Accepts", "application/json");

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(client.DownloadString(URL.ToString()));

                Console.WriteLine(jsonElement);

                return JsonSerializer.Serialize(jsonElement, options);

            }
            else if (input == "getLink")
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["listing_status"] = "active";
                queryString["start"] = "1";
                queryString["limit"] = "5";
                queryString["sort"] = "id";
                queryString["symbol"] = "LINK";
                queryString["aux"] = "platform,first_historical_data,last_historical_data,is_active";

                //queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                client.Headers.Add("Accepts", "application/json");

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(client.DownloadString(URL.ToString()));

                Console.WriteLine(jsonElement);

                return JsonSerializer.Serialize(jsonElement, options);

            }
            else
            {
                Console.WriteLine("Error, Please enter: GetAll, GetBTC, GetETH, getXRP or getLINK ");
            }

            Console.WriteLine("test");

            return input;
            
        }

    }
}
