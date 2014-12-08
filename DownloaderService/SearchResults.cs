using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderService
{
    [DataContract]
    public class SearchResults
    {
        [DataMember(Name = "resultCount")]
        public int Count;

        [DataMember(Name = "results")]
        public SearchResultItem[] Items;
    }
}
