using DownloaderService;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastGrabba.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private iTunesSearcher searcher;
        private IEnumerable<string> items;
        private int searchProgress;
        private string searchBoxText;
        private bool isSearching;

        public SearchViewModel()
        {
            this.searcher = new iTunesSearcher();
            this.SearchCommand = new RelayCommand(this.OnSearch);
        }

        public RelayCommand SearchCommand { get; set; }

        public string SearchBoxText
        {
            get
            {
                return this.searchBoxText;
            }

            set
            {
                this.searchBoxText = value;
                this.RaisePropertyChanged("SearchBoxText");
            }
        }
        
        public IEnumerable<string> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
                this.RaisePropertyChanged("Items");
            }
        }

        public bool IsSearching
        {
            get
            {
                return this.isSearching;
            }

            set
            {
                this.isSearching = value;
                this.RaisePropertyChanged("IsSearching");
            }
        }

        async private void OnSearch()
        {
            if (string.IsNullOrEmpty(this.SearchBoxText))
            {
                return;
            }

            this.IsSearching = true;
            var results = await this.searcher.SearchAsync(this.SearchBoxText);
            this.Items = results.Items.Select(item => item.CollectionName);
            this.IsSearching = false;
        }
    }
}
