using DownloaderService;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace PodcastGrabba.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IEnumerable<string> items;
        private RssDownloader rssDownloader;
        private int searchProgress;

        public MainPageViewModel()
        {
            this.rssDownloader = new RssDownloader("http://www.giantbomb.com/podcast-xml/giant-bombcast/");
            this.GrabCommand = new RelayCommand(this.OnGrab);
        }

        public RelayCommand GrabCommand { get; set; }

        public float GrabProgress
        {
            get
            {
                return this.rssDownloader.PercentComplete;
            }
        }

        async private void OnGrab()
        {
            var items = await this.rssDownloader.LoadFeedAsync();
        }
    }
}
