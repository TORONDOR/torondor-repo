using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    class BasePlugin<T>
    {
        public T data { get; }
        public IPlugin<T> plugin { get; }

        public BasePlugin(IPlugin<T> plugin, T data)
        {
            this.plugin = plugin;
            this.data = data;
        }

        public void Print()
        {
            T newData = plugin.Modify(data);
            Console.WriteLine(newData);
        }

    }
}
