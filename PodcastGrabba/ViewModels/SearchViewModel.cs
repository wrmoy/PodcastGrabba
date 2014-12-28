using DownloaderService;
using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PodcastGrabba.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        private IPodcastSearcher searcher;
        private IEnumerable<string> items;
        private string searchBoxText;
        private bool isSearching;

        public SearchViewModel(IPodcastSearcher searcher)
        {
            this.searcher = searcher;
            this.SearchCommand = new DelegateCommand(this.OnSearch);
        }

        public ICommand SearchCommand { get; set; }

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
        
        public IEnumerable<string> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
                this.OnPropertyChanged(() => this.Items);
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
            this.Items = results.Items.Select(item => item.CollectionName);
            this.IsSearching = false;
        }
    }
}
