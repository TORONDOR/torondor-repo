using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Interfaces
{
    interface IModify<T>
    {
        T Modify(T t);
    }
}
