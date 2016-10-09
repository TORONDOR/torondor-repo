using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;
using Plugin.Plugins;

namespace Plugin
{
    class Program
    {
        static void Main(string[] args)
        {
            PlugCollection plC = new PlugCollection();
            IPlugin plugInt = new PlugInt();
            IPlugin plugDate = new PlugDate();
            IPlugin plugString = new PlugString();
            plC.Add(plugInt);
            plC.Add(plugDate);
            plC.Add(plugString);
            plC.Modify("Plugin collection example:");
            Console.WriteLine("Base class example:");
            BasePlug<double> baseClass = new BasePlug<double>();
            baseClass.Data = 24;
            baseClass.Print();
            Console.WriteLine("Plugin&Pluginable example:");
            PlugPluginable pl = new PlugPluginable();
            Console.WriteLine(pl.Modify(2.3));
            Console.ReadLine();
        }
    }
}
