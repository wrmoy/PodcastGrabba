using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace DownloaderService
{
    public class iTunesSearcher
    {
        private const string SearchLocation = "https://itunes.apple.com/search";
        private HttpClient httpClient;

        public iTunesSearcher()
        {
            this.httpClient = new HttpClient();
        }

        async public Task<SearchResults> SearchAsync(string searchTerm)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", searchTerm);
            parameters.Add("media", "podcast");
            var uri = new Uri(SearchLocation + this.BuildEncodedParameters(parameters));

            var getTask = this.httpClient.GetAsync(uri);
            var response = await getTask;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var readContentTask = response.Content.ReadAsInputStreamAsync();
            var contentStream = await readContentTask;
            var serializer = new DataContractJsonSerializer(typeof(SearchResults));
            var results = serializer.ReadObject(contentStream.AsStreamForRead()) as SearchResults;
            return results;
        }

        private string BuildEncodedParameters(Dictionary<string, string> unencodedParameters)
        {
            if (unencodedParameters.Count == 0)
            {
                return string.Empty;
            }

            var encodedParameters = unencodedParameters.Select(kvp => WebUtility.UrlEncode(kvp.Key) + "=" + WebUtility.UrlEncode(kvp.Value));
            return encodedParameters.Aggregate("?", (current, next) => current += "&" + next);
        }
    }
}
