using System.Runtime.Serialization;

namespace InternetServices.Interfaces
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
