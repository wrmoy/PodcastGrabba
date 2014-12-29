using ApplicationServices.Interfaces.Settings;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PodcastGrabba.MockViewModels
{
    public class MockUserPodcastsViewModel : ViewModel
    {
        private List<FeedEntry> userFeeds = new List<FeedEntry>();

        public MockUserPodcastsViewModel()
        {
            for (var i = 0; i < 50; i++)
            {
                this.userFeeds.Add(new FeedEntry { FeedName = "Feed " + i.ToString() });
            }
        }

        public IEnumerable<FeedEntry> UserFeeds
        {
            get
            {
                return this.userFeeds;
            }
        }
    }
}
