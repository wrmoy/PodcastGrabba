using InternetServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace InternetServices
{
    public class iTunesSearcher : IPodcastSearcher
    {
        private const string SearchLocation = "https://itunes.apple.com/search";
        private IHttpClientWrapper httpClient;
        private DataContractJsonSerializer serializer;

        public iTunesSearcher(IHttpClientWrapper httpClient)
        {
            this.httpClient = httpClient;
            this.serializer = new DataContractJsonSerializer(typeof(SearchResults));
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
            var results = this.serializer.ReadObject(contentStream.AsStreamForRead()) as SearchResults;
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
