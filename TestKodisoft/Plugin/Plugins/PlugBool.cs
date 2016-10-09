using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;

namespace Plugin.Plugins
{
    //Plugin for boolean variables
    public class PlugBool : IPlugin, IModify<bool>
    {
        public bool Modify(bool b)
        {
            return !b;
        }

        public string PlugType()
        {
            return "bool";
        }
    }
}
