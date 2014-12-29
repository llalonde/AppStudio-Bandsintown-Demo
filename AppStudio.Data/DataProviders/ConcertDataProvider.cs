using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

using AppStudio.Data.DataSchemas;
using Newtonsoft.Json;

namespace AppStudio.Data.DataProviders
{
    public class ConcertDataProvider
    {
        private string _uri = "http://api.bandsintown.com/artists/{0}/events.json?app_id=MyFanApp";
        private string _artistId;
        public ConcertDataProvider(string artistId)
        {
            _artistId = artistId;
        }
        public async Task<ObservableCollection<ConcertSchema>> Load()
        {
            Uri concertsUri = new Uri(string.Format(_uri, _artistId), UriKind.Absolute);
            string concertsJsonResult = await DownloadAsync(concertsUri);

            var result = JsonConvert.DeserializeObject<ObservableCollection<ConcertSchema>>(concertsJsonResult);
            return result;
        }

        private async Task<string> DownloadAsync(Uri url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url.AbsoluteUri);
        }
    }
}


