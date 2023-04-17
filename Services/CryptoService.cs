using InfoVip.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace InfoVip.Services
{
    public class CryptoService: ICryptoService
    {
        public DBContext ctx = new DBContext();

        public static string API_KEY = "";

        static Currency makeAPICall(string id)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/category");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["id"] = id;

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            var apiresponse = client.DownloadString(URL.ToString());
            return JsonConvert.DeserializeObject<Currency>(apiresponse);
        }

        public Currency getPrices()
        {
            API_KEY = (from key in ctx.apiKeys
                       select key).FirstOrDefault().apikey;
            var portfolioIDs = (from port in ctx.apiportfolioIDs
                                select port).ToList();
            var result = new Currency();
            result.data = new Data();
            result.data.coins = new List<Coins>();
            portfolioIDs.ForEach(x =>
            {
                var resultapi = makeAPICall(x.id);

                List<int> coinids = x.coinid.Split(',').Select(int.Parse).ToList();

                resultapi.data.coins = resultapi.data.coins.Where(y => coinids.Any(c => c == y.id)).ToList();
                result.data.coins.AddRange(resultapi.data.coins);
            });

            return result;
        }
    }
}
