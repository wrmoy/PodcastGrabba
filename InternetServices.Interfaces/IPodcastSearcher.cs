using System.Threading.Tasks;

namespace InternetServices.Interfaces
{
    public interface IPodcastSearcher
    {
        Task<SearchResults> SearchAsync(string searchTerm);
    }
}
