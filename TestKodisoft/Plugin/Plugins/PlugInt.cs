using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;
using Plugin.Interfaces;

namespace Plugin.Plugins
{
    //Plugin for integer variables
    class PlugInt : IPlugin, IModify<int>
    {
        public int Modify(int i)
        {
            return Math.Abs(i);
        }

        public string PlugType()
        {
            return "int";
        }
    }
}
