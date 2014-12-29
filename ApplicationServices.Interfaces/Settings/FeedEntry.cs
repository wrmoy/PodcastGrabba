using System;
using System.Runtime.Serialization;

namespace ApplicationServices.Interfaces.Settings
{
    [DataContract]
    public class FeedEntry : IEquatable<FeedEntry>
    {
        [DataMember]
        public string FeedName { get; set; }

        public bool Equals(FeedEntry other)
        {
            return this.FeedName == other.FeedName;
        }
    }
}
