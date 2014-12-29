using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DownloaderService
{
    [DataContract]
    public class SearchResultItem
    {
        [DataMember(Name = "artistName")]
        public string ArtistName { get; set; }

        [DataMember(Name = "trackName")]
        public string TrackName { get; set; }

        [DataMember(Name = "collectionName")]
        public string CollectionName { get; set; }

        [DataMember(Name = "feedUrl")]
        public string FeedUrl { get; set; }

        [DataMember(Name = "artworkUrl30")]
        public string ArtworkUrl30 { get; set; }

        [DataMember(Name = "artworkUrl60")]
        public string ArtworkUrl60 { get; set; }

        [DataMember(Name = "artworkUrl100")]
        public string ArtworkUrl100 { get; set; }

        [DataMember(Name = "artworkUrl600")]
        public string ArtworkUrl600 { get; set; }

        [DataMember(Name = "trackCount")]
        public string TrackCount { get; set; }
    }
}
