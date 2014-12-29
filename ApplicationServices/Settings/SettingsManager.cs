using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.savedFeeds.Value.Add(feed);
        }

        public void RemoveFeed(FeedEntry feed)
        {
            if (this.savedFeeds.Value.Contains(feed))
            {
                this.savedFeeds.Value.Remove(feed);
            }
        }
    }
}
