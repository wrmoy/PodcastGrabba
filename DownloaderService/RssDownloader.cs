using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Xml.Dom;
using Windows.Web.Syndication;

namespace DownloaderService
{
    public class RssDownloader
    {
        private string uriString;

        public RssDownloader(string uriString)
        {
            this.uriString = uriString;
        }

        async public Task<IEnumerable<string>> LoadFeedAsync()
        {
            var syndicationClient = new SyndicationClient();
            var retreiveFeedTask = syndicationClient.RetrieveFeedAsync(new Uri(this.uriString));
            retreiveFeedTask.Progress = (info, progress) => this.PercentComplete = progress.BytesRetrieved / (float)progress.TotalBytesToRetrieve;
            var feed = await retreiveFeedTask;
            return feed.Items.Select(item => item.Title.Text);
        }

        public float PercentComplete { get; set; }
    }
}
