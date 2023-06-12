using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDemos
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        //public override string Draw()
        public new string Draw()
        {
            return "Drawing a circle";
        }
    }

}
