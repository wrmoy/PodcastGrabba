using System;
using Windows.Foundation;
using Windows.Web.Http;

namespace InternetServices.Interfaces
{
    public interface IHttpClientWrapper
    {
        IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> GetAsync(Uri uri);
    }
}
