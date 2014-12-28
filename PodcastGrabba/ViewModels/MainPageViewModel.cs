using DownloaderService;
using Infrastructure;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace PodcastGrabba.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private RssDownloader rssDownloader;

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
