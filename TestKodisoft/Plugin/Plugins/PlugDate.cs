using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;

namespace Plugin.Plugins
{
    //Plugin for DateTime variables
    class PlugDate : IPlugin, IModify<DateTime>
    {
        public DateTime Modify(DateTime date)
        {
            return date.ToLocalTime();
        }

        public string PlugType()
        {
            return "DateTime";
        }
    }
}
