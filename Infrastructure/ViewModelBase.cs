using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var properties = this.GetType().GetRuntimeProperties();
            if (properties == null || properties.FirstOrDefault(prop => prop.Name == propertyName) == null)
            {
                throw new Exception(String.Format("Could not find property \"{0}\"", propertyName));
            }

            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
