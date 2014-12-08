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
        public string ArtistName;

        [DataMember(Name = "trackName")]
        public string TrackName;

        [DataMember(Name = "collectionName")]
        public string CollectionName;

        [DataMember(Name = "feedUrl")]
        public string FeedUrl;

        [DataMember(Name = "artworkUrl30")]
        public string ArtworkUrl30;

        [DataMember(Name = "artworkUrl60")]
        public string ArtworkUrl60;

        [DataMember(Name = "artworkUrl100")]
        public string ArtworkUrl100;

        [DataMember(Name = "artworkUrl600")]
        public string ArtworkUrl600;

        [DataMember(Name = "trackCount")]
        public string TrackCount;
    }
}
