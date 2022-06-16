using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace FileSer
{
    public class Program
    {
        public static void Main(string[] s)
        {
            Console.WriteLine("Simple Serialization...");
            SerSimple st = new SerSimple();
            st.SerializeNow();
            st.DeSerializeNow();

            // Serialize sub-classes.
            Console.WriteLine("\nSerialization of sub-class...");
            SerSubClass st2 = new SerSubClass();
            st2.SerializeNow();
            st2.DeSerializeNow();

            // Serialize array of objects.
            Console.WriteLine("\nSerialization of array of objects...");
            SerArrayOfObjects st3 = new SerArrayOfObjects();
            st3.SerializeNow();
            st3.DeSerializeNow();
        }
    }
}