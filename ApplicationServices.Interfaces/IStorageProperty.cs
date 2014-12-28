using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IStorageProperty<T>
    {
        public bool Exists { get; }
        public T Value { get; set; }
    }
}
