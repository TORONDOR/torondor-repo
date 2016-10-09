using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task1
{
    static class CloneObject
    {
        //Method clone realized through serialization and deserialisation of streams
        public static T Clone<T>(this T objectToClone)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            T clone;

            if (ReferenceEquals(objectToClone, null))
                return default(T);

            using (stream)
            {
                formatter.Serialize(stream, objectToClone);
                stream.Seek(0, SeekOrigin.Begin);
                clone = (T)formatter.Deserialize(stream);
            }

            return clone;
        }
    }
}
