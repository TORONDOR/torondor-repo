using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;

namespace Plugin.Plugins
{
    //Plugin for string variables
    class PlugString : IPlugin, IModify<string>
    {
        public string Modify(string str)
        {
            return str.ToUpper();
        }

        public string PlugType()
        {
            return "String";
        }
    }
}
