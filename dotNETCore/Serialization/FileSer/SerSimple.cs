using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileSer
{
    public class SerSimple
    {
        public void SerializeNow()
        {
            var filename = @"c:\temp\temp.dat";
            Console.WriteLine($"Writing to file {filename}...");

            ClassToSerialize cls = new ClassToSerialize();
            Stream saveFileStream = File.Create(filename);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(saveFileStream, cls);
            saveFileStream.Close();

            Console.WriteLine($"Done!");
        }
        public void DeSerializeNow()
        {
            var filename = @"c:\temp\temp.dat";
            Console.WriteLine($"Reading file {filename}...");

            ClassToSerialize cls = new ClassToSerialize();
            if (File.Exists(filename))
            {
                Stream openFileStream = File.OpenRead(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                cls = (ClassToSerialize)serializer.Deserialize(openFileStream);
                Console.WriteLine(cls.name);
                openFileStream.Close();
            }
            Console.WriteLine($"Done!");
        }
    }
    [Serializable]
    public class ClassToSerialize
    {
        public int age = 100;
        public string name = "Ajay Singala";
        //[field: NonSerialized()]
        public string city = "Boston";
    }
}