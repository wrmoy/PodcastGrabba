using DownloaderService;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;

namespace PodcastGrabba.MockViewModels
{
    public class MockSearchViewModel : ViewModel
    {
        private IList<SearchResultItem> items = new List<SearchResultItem>();

        public MockSearchViewModel()
        {
            for (var i = 0; i < 50; i++)
            {
                this.items.Add(new SearchResultItem { CollectionName = "Collection" + i.ToString(), ArtistName = "Artist" + i.ToString() });
            }
        }

        public IEnumerable<SearchResultItem> SearchResultItems
        {
            get
            {
                return this.items;
            }
        }

        public bool IsSearching
        {
            get
            {
                return true;
            }
        }
    }
}
