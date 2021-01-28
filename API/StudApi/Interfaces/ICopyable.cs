using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudApi.Interfaces
{
    interface ICopyable<T>
    {
        void CopyProperties(T data);
    }
}
