using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task3
{
    public class AssembliesClass
    {
        private object locker;

        public Dictionary<Type, ConstructorInfo> Dictionary;

        public AssembliesClass()
        {
            Dictionary = new Dictionary<Type, ConstructorInfo>();
            locker = new object();
        }

        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }

        //Method which collect dictionary, where key is Type and value is reference to default ctor.
        //If there is no default ctor, ignore type.
        public void Scanning()
        {
            lock (locker)
            {
                try
                {
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        var type = assembly.GetTypes()[0];
                        if (type.GetConstructor(Type.EmptyTypes) != null)
                            lock (Dictionary)
                                if (!Dictionary.ContainsKey(type))
                                    Dictionary.Add(type, type.GetConstructor(Type.EmptyTypes));
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void PrintRef()
        {
            foreach (var item in Dictionary)
            {
                lock (Dictionary)
                    Console.WriteLine("Key = {0}", item.Key);
                Console.WriteLine("Value = {0}", item.Value);
                Console.WriteLine();
            }
        }
    }
}