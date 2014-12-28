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
        internal readonly List<FeedEntry> savedFeeds = new List<FeedEntry>();

        public IReadOnlyCollection<FeedEntry> SavedFeeds
        {
            get { return this.savedFeeds; }
        }

        public void AddFeed(FeedEntry feed)
        {
            throw new NotImplementedException();
        }

        public void RemoveFeed(FeedEntry feed)
        {
            throw new NotImplementedException();
        }
    }
}
