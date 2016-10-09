using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;

namespace Plugin.Plugins
{
    //Plugin for double variables
    public class PlugDouble : IPlugin, IModify<double>
    {
        public double Modify(double value)
        {
            return Math.Abs(value);
        }

        public string PlugType()
        {
            return "double";
        }
    }
}
