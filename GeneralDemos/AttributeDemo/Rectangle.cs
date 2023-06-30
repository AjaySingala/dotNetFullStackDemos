using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [DeBugInfo(45, "John Smith", "12/02/2023", Message = "Return type mismatch")]
    [DeBugInfo(49, "Mary Jane", "10/01/2023", Message = "Unused variable")]
    [Author("Ajay Singala", Version=0.1)]
    //[Author("John Smith"), Author("Mary Jane", Version = 2.0)]
    public class Rectangle
    {
        protected double length;
        protected double width;
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }


        [DeBugInfo(55, "John Smith", "19/02/2023", Message = "Return type mismatch")]
        public double GetArea()
        {
            return length * width;
        }

        [DeBugInfo(56, "John Smith", "19/02/2023")]

        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}
