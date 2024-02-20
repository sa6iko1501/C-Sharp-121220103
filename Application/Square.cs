using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /*
     * I have decided to use Square as the other base shape size instead of Rectangle as formulas for
     * calculating area and perimeter of rectangle are more complex and require more variables so it's
     * easier to inherit and override constructor and methods of Square Class instead of a Rectangle class.
     * I have still implemented the static method that returns the area of a Square by a given value for ít's side 'a'.
    */

    internal class Square : Shape, ICheckShapeForOval
    {
        private double A { get; set; }
        public Square(double a) {
            A = a;
        }
        public override double area()
        {
            return A * A;
        }

        public override double perimeter()
        {
            return 4 * A;
        }

        public bool isOval()
        {
            return false;
        }

        public static double getAreaWithoutInstance(double a)
        {
            return a * a;
        }
        
    }
}
