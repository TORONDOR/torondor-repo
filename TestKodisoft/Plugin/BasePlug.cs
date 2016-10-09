using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Interfaces;

namespace Plugin
{
    public class BasePlug<T>
    {
        private IPlugin plugin { get; set; }
        public T Data { get; set; }
        protected Type _plugType;

        public BasePlug()
        {
            _plugType = typeof(T);
            plugin = Factory.Create(_plugType);
        }

        public void Print()
        {
            Console.WriteLine((this.plugin as IModify<T>).Modify(this.Data));
        }
    }
}
