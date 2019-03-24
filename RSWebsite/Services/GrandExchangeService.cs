using RSWebsite.Interfaces;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RSWebsite.Services
{
    public class GrandExchangeService : IGrandExchangeService
    {
        private const string _baseUrl = "http://services.runescape.com/m=itemdb_oldschool";
        private const string _itemEndpoint = "/api/catalogue/detail.json?item={0}";
        private const string _itemChartEndpoint = "/api/graph/{0}.json";
        private const string _itemUrl = _baseUrl + _itemEndpoint;
        private const string _itemChartUrl = _baseUrl + _itemChartEndpoint;

        private async Task<string> GetApiResponse(string endpoint)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(endpoint);
            using (HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }
        public async Task<string> GetItemChart(string itemId)
        {
            string endpoint = string.Format(_itemChartUrl, itemId);
            return await GetApiResponse(endpoint);
        }

        public async Task<string> GetItem(string itemId)
        {
            string endpoint = string.Format(_itemUrl, itemId);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(endpoint);
            using (HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }
    }
}
