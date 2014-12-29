using System.Runtime.Serialization;

namespace ApplicationServices.Interfaces.Settings
{
    [DataContract]
    public class FeedEntry
    {
        [DataMember]
        public string FeedName { get; set; }
    }
}
