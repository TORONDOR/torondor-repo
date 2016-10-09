using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;

namespace Plugin.Plugins
{
    //Pluginable plugin
    public class PlugPluginable : IPlugin, IModify<double>
    {
        public double Modify(double param)
        {
            double temp = param * 2;
            PlugDouble doub = new PlugDouble();
            return doub.Modify(temp);
        }

        public string PlugType()
        {
            return "PlugPluginable";
        }
    }
}
