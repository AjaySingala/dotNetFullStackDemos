using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSer
{
    public class Employee
    {
        public string EmpName;
        public string EmpID;
        public Employee() { }
        public Employee(string empName, string empID)
        {
            EmpName = empName;
            EmpID = empID;
        }
    }

    public class Employees : ICollection
    {
        public string CollectionName;
        private ArrayList empArray = new ArrayList();

        public Employee this[int index]
        {
            get { return (Employee)empArray[index]; }
        }

        public int Count
        {
            get { return empArray.Count; }
        }

        public void CopyTo(Array a, int index)
        {
            empArray.CopyTo(a, index);
        }

        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return empArray.GetEnumerator();
        }

        public void Add(Employee newEmployee)
        {
            empArray.Add(newEmployee);
        }


    }

    public class SerCollection
    {
        public void Ser()
        {
            Console.WriteLine("Serialize a Class that Implements the ICollection Interface....");

            var filename = @"C:\temp\emp.xml";
            Employees emps = new Employees();
            // Note that only the collection is serialized -- not the
            // CollectionName or any other public property of the class.
            emps.CollectionName = "Employees";
            Employee John100 = new Employee("John", "100xxx");
            emps.Add(John100);

            Employee Mary200 = new Employee { EmpID = "200xxx", EmpName = "Mary Jane" };
            emps.Add(Mary200);

            XmlSerializer x = new XmlSerializer(typeof(Employees));
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, emps);
            writer.Close();

            Console.WriteLine("Done!");
        }

        public void DeSer()
        {
            Console.WriteLine("De-Serialize a Class that Implements the ICollection Interface...");

            var mySerializer = new XmlSerializer(typeof(Employees));
            // To read the file, create a FileStream.
            using (var myFileStream = new FileStream(@"C:\Temp\emp.xml", FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.
                var myObject = (Employees)mySerializer.Deserialize(myFileStream);
                for (int i = 0; i < myObject.Count; i++)
                {
                    Console.WriteLine($"Id: {myObject[i].EmpID}. Name: {myObject[i].EmpName}");
                }
            }

            Console.WriteLine("Done!");
        }
    }
}
