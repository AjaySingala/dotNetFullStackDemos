using System.Xml.Serialization;

namespace XmlSer
{
    public class Program
    {
        public static void Main(string[] s)
        {
            // Serialize object.
            SerObject();
            DeSerObject();

            // Serialize a class that contains a field.
            SerClasses sc = new SerClasses();
            sc.Ser();
            sc.DeSer();

            // Serialize an array of objects.
            SerArrayOfObjects sa = new SerArrayOfObjects();
            sa.Ser();
            sa.DeSer();

            // Serialize a Class that Implements the ICollection Interface.
            SerCollection sc2 = new SerCollection();
            sc2.Ser();
            sc2.DeSer();
        }

        private static void SerObject()
        {
            Console.WriteLine("XML Object Serialization...");

            MySerializableClass myObject = new MySerializableClass()
            {
                Id = 101,
                Firstname = "John",
                Lastname = "Smith"
            };

            XmlSerializer mySerializer = new
            XmlSerializer(typeof(MySerializableClass));
            // To write to a file, create a StreamWriter object.  
            StreamWriter myWriter = new StreamWriter(@"C:\Temp\myFileName.xml");
            mySerializer.Serialize(myWriter, myObject);
            myWriter.Close();
            
            Console.WriteLine("Done!");
        }

        private static void DeSerObject()
        {
            Console.WriteLine("XML Object De-Serialization...");

            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            var mySerializer = new XmlSerializer(typeof(MySerializableClass));
            // To read the file, create a FileStream.
            using (var myFileStream = new FileStream(@"C:\Temp\myFileName.xml", FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.
                var myObject = (MySerializableClass)mySerializer.Deserialize(myFileStream);
                Console.WriteLine($"Id: {myObject.Id} Name: {myObject.Firstname} {myObject.Lastname}");
            }

            Console.WriteLine("Done!");
        }
    }
}
