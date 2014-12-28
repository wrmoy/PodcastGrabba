using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ApplicationServices.Interfaces
{
    public class RoamingStorageProperty<T> : IStorageProperty<T>
    {
        private readonly ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;

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

                return (T)this.settings.Values[this.name];
            }

            set
            {
                this.settings.Values[this.name] = value;
            }
        }

        private void SetDefault()
        {
            if (!this.Exists)
            {
                this.Value = this.defaultValue;
            }
        }
    }
}
