using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Rectangle : Square
    {
        private double A { get; set; }
        private double B { get; set; }
        public Rectangle(double a, double b) : base(a)
        {
            A=a; B=b;
        }
        public override double area()
        {
            return A * B;
        }
        public override double perimeter()
        {
            return (A + B) * 2;
        }
    }
}
