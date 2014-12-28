using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;

namespace DownloaderService
{
    public interface IHttpClientWrapper
    {
        IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> GetAsync(Uri uri);
    }
}
