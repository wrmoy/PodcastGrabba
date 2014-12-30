using ApplicationServices.Interfaces.Settings;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PodcastGrabba.ViewModels
{
    public class UserPodcastsViewModel : ViewModel
    {
        private ISettingsManager settingsManager;

        public UserPodcastsViewModel(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;

            this.UnsubscribeCommand = new DelegateCommand<object>(this.OnUnsubscribe);
        }

        public ICommand UnsubscribeCommand { get; private set; }

        public ObservableCollection<FeedEntry> UserFeeds
        {
            get
            {
                return this.settingsManager.SavedFeeds;
            }
        }

        private void OnUnsubscribe(object parameter)
        {
            var feedEntry = parameter as FeedEntry;
            this.settingsManager.RemoveFeed(feedEntry);
        }
    }
}
