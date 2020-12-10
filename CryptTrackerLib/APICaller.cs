using System;
using System.Net;
using System.Text.Json;
using System.Web;

class CSharpExample
{
    private static string API_KEY = "be39bd63-d630-446c-8b1f-dd243fda85cc";

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(makeAPICall());
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static string makeAPICall()
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
        queryString["symbol"] = "BTC";
        queryString["aux"] = "platform,first_historical_data,last_historical_data,is_active";

        //queryString["convert"] = "USD";

        URL.Query = queryString.ToString();

        var client = new WebClient();
        client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
        client.Headers.Add("Accepts", "application/json");

        var jsonElement = JsonSerializer.Deserialize<JsonElement>(client.DownloadString(URL.ToString()));

        return JsonSerializer.Serialize(jsonElement, options);

    }

}