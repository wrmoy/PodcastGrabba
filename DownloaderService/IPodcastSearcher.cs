using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderService
{
    public interface IPodcastSearcher
    {
        Task<SearchResults> SearchAsync(string searchTerm);
    }
}
