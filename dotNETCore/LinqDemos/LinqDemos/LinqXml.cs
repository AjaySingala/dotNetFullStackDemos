using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqDemos
{
    public class LinqXml
    {
        public static void Run()
        {
            Console.WriteLine("Linq Xml...");
            string myXML = @"
                <Users>
                    <User>
                        <Name>Jack</Name>
                        <Sex>male</Sex>
                    </User>
                    <User>
                        <Name>Paul</Name>
                        <Sex>male</Sex>
                    </User>
                    <User>
                        <Name>Frank</Name>
                        <Sex>male</Sex>
                    </User>
                    <User>
                        <Name>Martina</Name>
                        <Sex>female</Sex>
                    </User>
                    <User>
                        <Name>Lucia</Name>
                        <Sex>female</Sex>
                    </User>
                </Users>";

            var xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            var females = from u in xdoc.Root.Descendants()
                          where (string)u.Element("Sex") == "female"
                          select u.Element("Name");

            foreach (var e in females)
            {
                Console.WriteLine("{0}", e);
            }

            Console.WriteLine();
        }
    }
}
