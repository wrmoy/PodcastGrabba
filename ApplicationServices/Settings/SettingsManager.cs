using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Settings;
using System.Collections.Generic;

namespace ApplicationServices.Settings
{
    public class SettingsManager : ISettingsManager
    {
        internal const string SavedFeedsKey = "SavedFeeds";
        internal readonly IStorageProperty<List<FeedEntry>> savedFeeds;

        public SettingsManager()
        {
            this.savedFeeds = new RoamingStorageProperty<List<FeedEntry>>(SavedFeedsKey, new List<FeedEntry>());
        }

        public IReadOnlyCollection<FeedEntry> SavedFeeds
        {
            get { return this.savedFeeds.Value; }
        }

        public void AddFeed(FeedEntry feed)
        {
            if (!this.savedFeeds.Value.Contains(feed))
            {
                var entries = this.savedFeeds.Value;
                entries.Add(feed);
                this.savedFeeds.Value = entries;
            }
        }

        public void RemoveFeed(FeedEntry feed)
        {
            if (this.savedFeeds.Value.Contains(feed))
            {
                var entries = this.savedFeeds.Value;
                entries.Remove(feed);
                this.savedFeeds.Value = entries;
            }
        }
    }
}
