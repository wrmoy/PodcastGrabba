using ApplicationServices.Interfaces.Settings;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastGrabba.ViewModels
{
    public class UserPodcastsViewModel : ViewModel
    {
        private ISettingsManager settingsManager;

        public UserPodcastsViewModel(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;
        }

        public IEnumerable<FeedEntry> UserFeeds
        {
            get
            {
                return this.settingsManager.SavedFeeds;
            }
        }
    }
}
