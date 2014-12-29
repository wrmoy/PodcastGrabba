﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IStorageProperty<T>
    {
        bool Exists { get; }
        T Value { get; set; }
    }
}
