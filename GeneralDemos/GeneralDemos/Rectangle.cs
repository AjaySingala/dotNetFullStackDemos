using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDemos
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        // Polymorphism.
        public override string GetShapeType()
        {
            return "This is a rectangle";
        }

        //public override string Draw()
        public new string Draw()
        {
            return "Drawing a rectangle";
        }
    }

}
