using InternetServices.Interfaces;
using System;
using Windows.Foundation;
using Windows.Web.Http;

namespace InternetServices
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient httpClient = new HttpClient();

        public IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> GetAsync(Uri uri)
        {
            return this.httpClient.GetAsync(uri);
        }
    }
}
