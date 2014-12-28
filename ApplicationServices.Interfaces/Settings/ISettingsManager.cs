using System.Collections.Generic;

namespace ApplicationServices.Interfaces.Settings
{
    public interface ISettingsManager
    {
        IReadOnlyCollection<FeedEntry> SavedFeeds { get; }
        void AddFeed(FeedEntry feed);
        void RemoveFeed(FeedEntry feed);
    }
}
