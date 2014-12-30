using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApplicationServices.Interfaces.Settings
{
    public interface ISettingsManager
    {
        ObservableCollection<FeedEntry> SavedFeeds { get; }
        void AddFeed(FeedEntry feed);
        void RemoveFeed(FeedEntry feed);
    }
}
