using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Examples of working Clone() method
            var number = 4.Clone();
            var str = "asdfasdf".Clone();
            var obj = new object().Clone();

            Console.WriteLine(number);
            Console.WriteLine(str);
            Console.WriteLine(obj);

            Console.ReadKey();
        }
    }
}
