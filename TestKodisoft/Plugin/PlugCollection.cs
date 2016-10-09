using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;
using Plugin.Plugins;
using System.Globalization;

namespace Plugin
{
    //Class collection for plugins
    class PlugCollection : IPlugin, IModify<string>
    {
        private List<IPlugin> pluginList = new List<IPlugin>();

        public string PlugType()
        {
            return "PluginCollector";
        }

        public string Modify(string param)
        {
            Console.WriteLine(param);
            foreach (var plugin in this.pluginList)
            {
                RunPlugins(plugin);
            }
            return "All plugins have been runned";
        }

        public void Add(IPlugin plugin)
        {
            pluginList.Add(plugin);
        }

        private void RunPlugins(IPlugin plugin)
        {
            try
            {
                string pluginName = plugin.PlugType();
                switch (pluginName)
                {
                    case "double":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<double>).Modify(-89).ToString());
                        Console.WriteLine();
                        break;

                    case "String":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<string>).Modify("THis is my life"));
                        Console.WriteLine();
                        break;

                    case "int":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<int>).Modify(6).ToString());
                        Console.WriteLine();
                        break;

                    case "PlugPluginable":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<double>).Modify(6.3).ToString());
                        Console.WriteLine();
                        break;

                    case "bool":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<bool>).Modify(true).ToString());
                        Console.WriteLine();
                        break;

                    case "DateTime":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<DateTime>).Modify(DateTime.Today).ToString());
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("No such plugin");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error when applied Plugins");
            }
        }
    }
}
