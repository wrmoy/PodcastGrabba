using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Windows.Storage;

namespace ApplicationServices.Interfaces
{
    public class RoamingStorageProperty<T> : IStorageProperty<T>
    {
        private readonly ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;
        private readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

        private string name;
        private T defaultValue;
        private object syncObject = new object();

        public RoamingStorageProperty(string name, T defaultValue = default(T))
        {
            this.name = name;
            this.defaultValue = defaultValue;
        }

        public bool Exists
        {
            get { return this.settings.Values.ContainsKey(name); }
        }

        public T Value
        {
            get
            {
                if (!this.Exists)
                {
                    lock(this.syncObject)
                    {
                        this.SetDefault();
                    }
                }

                return this.GetObjectFromBytes((byte[])this.settings.Values[this.name]);
            }

            set
            {
                this.settings.Values[this.name] = this.GetBytesFromObject(value);
            }
        }

        private void SetDefault()
        {
            if (!this.Exists)
            {
                this.Value = this.defaultValue;
            }
        }

        private byte[] GetBytesFromObject(T value)
        {
            using (var stream = new MemoryStream())
            {
                this.serializer.WriteObject(stream, value);
                stream.Flush();
                stream.Position = 0;
                byte[] bytes = new byte[stream.Length];
                var bytesRead = stream.Read(bytes, 0, bytes.Length);
                if (bytesRead != bytes.Length)
                {
                    throw new InvalidOperationException(string.Format("{0} bytes read, {1} bytes expected to be read", bytesRead, bytes.Length));
                }

                return bytes;
            }
        }

        private T GetObjectFromBytes(byte[] bytes)
        {
            using (var stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                return (T)this.serializer.ReadObject(stream);
            }
        }
    }
}
