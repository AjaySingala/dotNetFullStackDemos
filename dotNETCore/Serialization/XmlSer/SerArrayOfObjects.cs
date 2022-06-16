using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSer
{
    public class PurchaseOrder2
    {
        public string CustomerName { get; set; }
        public Item[] Items;
    }

    public class Item
    {
        public int ItemID;
        public string Name { get; set; }
        public decimal ItemPrice;
    }

    public class SerArrayOfObjects
    {
        public void Ser()
        {
            Console.WriteLine("Serialize a class that contains a field....");

            PurchaseOrder2 po = new PurchaseOrder2()
            {
                CustomerName = "Mary Jane",
                Items = new Item[]
                {
                    new Item { ItemID = 201, Name = "Pens", ItemPrice = 1.99M },
                    new Item { ItemID = 202, Name = "Pencils", ItemPrice = 1.49M },
                    new Item { ItemID = 203, Name = "Erasers", ItemPrice = 2.49M },
                }
            };

            XmlSerializer mySerializer = new
            XmlSerializer(typeof(PurchaseOrder2));
            // To write to a file, create a StreamWriter object.  
            StreamWriter myWriter = new StreamWriter(@"C:\Temp\po2.xml");
            mySerializer.Serialize(myWriter, po);
            myWriter.Close();

            Console.WriteLine("Done!");
        }

        public void DeSer()
        {
            Console.WriteLine("De-Serialize a class that contains a field...");

            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            var mySerializer = new XmlSerializer(typeof(PurchaseOrder2));
            // To read the file, create a FileStream.
            using (var myFileStream = new FileStream(@"C:\Temp\po2.xml", FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.
                var myObject = (PurchaseOrder2)mySerializer.Deserialize(myFileStream);
                Console.WriteLine($"Name: {myObject.CustomerName} purchased:");
                foreach(var item in myObject.Items)
                {
                    Console.WriteLine($"\t{item.Name}");
                }
            }

            Console.WriteLine("Done!");
        }
    }
}
