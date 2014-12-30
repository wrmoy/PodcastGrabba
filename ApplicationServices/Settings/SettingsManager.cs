using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Settings;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ApplicationServices.Settings
{
    public class SettingsManager : ISettingsManager
    {
        internal const string SavedFeedsKey = "SavedFeeds";
        internal readonly IStorageProperty<List<FeedEntry>> savedFeeds;
        internal readonly ObservableCollection<FeedEntry> observableFeeds;

        public SettingsManager()
        {
            this.savedFeeds = new RoamingStorageProperty<List<FeedEntry>>(SavedFeedsKey, new List<FeedEntry>());
            this.observableFeeds = new ObservableCollection<FeedEntry>(this.savedFeeds.Value);
        }

        public ObservableCollection<FeedEntry> SavedFeeds
        {
            get { return this.observableFeeds; }
        }

        public void AddFeed(FeedEntry feed)
        {
            if (!this.savedFeeds.Value.Contains(feed))
            {
                this.observableFeeds.Add(feed);
                this.savedFeeds.Value = this.observableFeeds.ToList();
            }
        }

        public void RemoveFeed(FeedEntry feed)
        {
            if (this.savedFeeds.Value.Contains(feed))
            {
                this.observableFeeds.Remove(feed);
                this.savedFeeds.Value = this.observableFeeds.ToList();
            }
        }
    }
}
