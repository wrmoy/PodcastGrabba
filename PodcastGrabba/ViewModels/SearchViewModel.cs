using ApplicationServices.Interfaces.Settings;
using DownloaderService;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.Windows.Input;

namespace PodcastGrabba.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        private IPodcastSearcher searcher;
        private ISettingsManager settingsManager;
        private IEnumerable<SearchResultItem> items;
        private string searchBoxText;
        private bool isSearching;

        public SearchViewModel(IPodcastSearcher searcher, ISettingsManager settingsManager)
        {
            this.searcher = searcher;
            this.settingsManager = settingsManager;

            this.SearchCommand = new DelegateCommand(this.OnSearch);
            this.SubscribeCommand = new DelegateCommand<object>(this.OnSubscribe);
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand SubscribeCommand { get; private set; }

        public string SearchBoxText
        {
            get
            {
                return this.searchBoxText;
            }

            set
            {
                this.searchBoxText = value;
                this.OnPropertyChanged(() => this.SearchBoxText);
            }
        }
        
        public IEnumerable<SearchResultItem> SearchResultItems
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
                this.OnPropertyChanged(() => this.SearchResultItems);
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
                this.OnPropertyChanged(() => this.IsSearching);
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
            this.SearchResultItems = results.Items;
            this.IsSearching = false;
        }

        private void OnSubscribe(object parameter)
        {
            var resultItem = parameter as SearchResultItem;
            var feedEntry = new FeedEntry { FeedName = resultItem.CollectionName };
            this.settingsManager.AddFeed(feedEntry);
        }
    }
}
