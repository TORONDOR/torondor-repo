using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;
using Plugin.Plugins;

namespace Plugin
{
    //Class which create new instance of plugin of concrete type
    class Factory
    {
        public static IPlugin Create(Type plugType)
        {
            switch (plugType.Name)
            {
                case "Int32":
                    return new PlugInt();

                case "Double":
                    return new PlugDouble();

                case "String":
                    return new PlugString();

                case "Date":
                    return new PlugDate();
                    
                case "Boolean":
                    return new PlugBool();

                case "PlugPluginable":
                    return new PlugPluginable();

                default:
                    Console.WriteLine("Unresolved type for PLugins. " + plugType);
                    break;
            }
            return null;
        }
    }
}
