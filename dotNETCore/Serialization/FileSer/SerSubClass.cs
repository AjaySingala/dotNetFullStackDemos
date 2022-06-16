using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileSer
{
    public class SerSubClass
    {
        public void SerializeNow()
        {
            var filename = @"c:\temp\temp2.dat";
            Console.WriteLine($"Writing to file {filename}...");

            ClassToSerialize2 cls = new ClassToSerialize2();
            cls.Name = "Mary Jane";
            cls.Age = 26;
            ClassToSerialize2.CompanyName = "xyz";
            Stream saveFileStream = File.Create(filename);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(saveFileStream, cls);
            saveFileStream.Close();
        }
        public void DeSerializeNow()
        {
            var filename = @"c:\temp\temp2.dat";
            Console.WriteLine($"Reading file {filename}...");

            ClassToSerialize2 cls = new ClassToSerialize2();
            if (File.Exists(filename))
            {
                Stream openFileStream = File.OpenRead(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                cls = (ClassToSerialize2)serializer.Deserialize(openFileStream);
                Console.WriteLine("Name :" + cls.Name);
                Console.WriteLine("Age :" + cls.Age);
                Console.WriteLine("Company Name :" + ClassToSerialize2.CompanyName);
                Console.WriteLine("Company Name :" + cls.GetSupportClassString());
                openFileStream.Close();
            }
        }
    }

    [Serializable]
    public class ClassToSerialize2
    {
        private int age;
        private string name;
        static string companyname;
        SupportClass supp = new SupportClass();
        public ClassToSerialize2()
        {
            supp.SupportClassString = "In support class";
        }
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
        public string GetSupportClassString()
        {
            return supp.SupportClassString;
        }
    }

    [Serializable]
    public class SupportClass
    {
        public string SupportClassString;
    }
}
