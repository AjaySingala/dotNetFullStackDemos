using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileSer
{
    public class SerArrayOfObjects
    {
        public void SerializeNow()
        {
            var filename = @"c:\temp\temp3.dat";
            Console.WriteLine($"Writing to file {filename}...");

            ClassToSerialize3[] cls = new ClassToSerialize3[3];
            cls[0] = new ClassToSerialize3();
            cls[0].Name = "bipin";
            cls[0].Age = 26;
            cls[1] = new ClassToSerialize3();
            cls[1].Name = "abc";
            cls[1].Age = 75;
            cls[2] = new ClassToSerialize3();
            cls[2].Name = "pqr";
            cls[2].Age = 50;
            ClassToSerialize3.CompanyName = "xyz";

            Stream saveFileStream = File.Create(filename);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(saveFileStream, cls);
            saveFileStream.Close();
        }
        public void DeSerializeNow()
        {
            var filename = @"c:\temp\temp3.dat";
            Console.WriteLine($"Reading file {filename}...");

            ClassToSerialize3[] cls;

            if (File.Exists(filename))
            {
                Stream openFileStream = File.OpenRead(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                cls = (ClassToSerialize3[])serializer.Deserialize(openFileStream);
                foreach (var item in cls)
                {
                    Console.WriteLine($"Name: {item.Name} Age: {item.Age} Company Name: {ClassToSerialize3.CompanyName}");
                }
                openFileStream.Close();
            }
        }
    }

    [Serializable]
    public class ClassToSerialize3
    {
        private int age;
        private string name;
        static string companyname;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public static string CompanyName
        {
            get
            {
                return companyname;
            }
            set
            {
                companyname = value;
            }
        }
    }
}
