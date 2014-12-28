using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;

namespace DownloaderService
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
