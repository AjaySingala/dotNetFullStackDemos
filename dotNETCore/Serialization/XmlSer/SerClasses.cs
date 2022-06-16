using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSer
{
    public class PurchaseOrder
    {
        public string CustomerName { get; set; }
        public Address MyAddress;
    }
    public class Address
    {
        public string City;

        // The XmlAttribute attribute instructs the XmlSerializer to serialize the
        // Name field as an XML attribute instead of an XML element (XML element is
        // the default behavior).
        [XmlAttribute]
        public string State { get; set; }
    }

    public class SerClasses
    {
        public void Ser()
        {
            Console.WriteLine("Serialize a class that contains a field....");

            PurchaseOrder po = new PurchaseOrder()
            {
                CustomerName = "Mary Jane",
                MyAddress = new Address()
                {
                    City = "Boston",
                    State = "MA"
                }
            };

            XmlSerializer mySerializer = new
            XmlSerializer(typeof(PurchaseOrder));
            // To write to a file, create a StreamWriter object.  
            StreamWriter myWriter = new StreamWriter(@"C:\Temp\po1.xml");
            mySerializer.Serialize(myWriter, po);
            myWriter.Close();

            Console.WriteLine("Done!");
        }

        public void DeSer()
        {
            Console.WriteLine("De-Serialize a class that contains a field...");

            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            var mySerializer = new XmlSerializer(typeof(PurchaseOrder));
            // To read the file, create a FileStream.
            using (var myFileStream = new FileStream(@"C:\Temp\po1.xml", FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.
                var myObject = (PurchaseOrder)mySerializer.Deserialize(myFileStream);
                Console.WriteLine($"Name: {myObject.CustomerName} from {myObject.MyAddress.City}, {myObject.MyAddress.State}");
            }

            Console.WriteLine("Done!");
        }
    }
}
