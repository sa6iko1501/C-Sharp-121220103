using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Circle : Shape, ICheckShapeForOval
    {
        private double Radius {  get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double area()
        {
            return Math.PI * (Radius * Radius);
        }

        public override double perimeter()
        {
            return Math.PI * (Radius * 2);
        }

        public bool isOval()
        {
            return true;
        }
    }
}
