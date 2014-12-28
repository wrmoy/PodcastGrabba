using DownloaderService;
using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.Web.Syndication;

namespace PodcastGrabba.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private RssDownloader rssDownloader;

        public MainPageViewModel()
        {
            this.rssDownloader = new RssDownloader("http://www.giantbomb.com/podcast-xml/giant-bombcast/");
            this.GrabCommand = new DelegateCommand(this.OnGrab);
        }

        public ICommand GrabCommand { get; set; }

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
