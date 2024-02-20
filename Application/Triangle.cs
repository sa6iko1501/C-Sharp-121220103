using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Triangle<T> : Shape, ICheckShapeForOval
    {
        public T A { get; set; }
        public T B { get; set; }    
        public T C { get; set; }

        public override double area()
        {
            float area = 0;
            float x, y, z;
            // Check if we are getting something that can be converted to float since it will be valid for both float and int
            if (float.TryParse(A.ToString(), out x) && float.TryParse(B.ToString(), out y) && float.TryParse(C.ToString(), out z))
            {
                float halfPerimeter = (x + y + z) / 2;
                area = (float)Math.Sqrt(halfPerimeter * (halfPerimeter - x) * (halfPerimeter - y) * (halfPerimeter - z));
            }
            return Convert.ToDouble(area);
        }

        public bool isOval()
        {
            return false;
        }

        public override double perimeter()
        {
            float p = 0;
            
            float x, y, z;
            // Check if we are getting something that can be converted to float since it will be valid for both float and int
            if (float.TryParse(A.ToString(), out x) && float.TryParse(B.ToString(), out y) && float.TryParse(C.ToString(), out z))
            { 
                p = x + y + z;
            }
            return Convert.ToDouble(p);
        }

        /* We will declare the out variable of Triangle as nullable since we don't know wether it will pass our checks
         * and have another nullable String that will have the type(float or int) of the data for the triangle 
         */
        public static bool getInstance(T a, T b, T c, out Triangle<T> triangle, out String type)
        {
            bool isSuccessfull = false;
            triangle = null;
            // Check data type of sides
            if(a is int &&  b is int && c is int) 
            {
                type = "Int";
            }
            else
            {
                if (a is float && b is float && c is float)
                {
                    type = "Float";
                }
                else
                {
                    type = "Undefined";
                }
            }
            
            if(checkValidityOfSides(a, b, c))
            {
                triangle = new Triangle<T> { A = a, B = b, C = c};
                isSuccessfull = true;
            }
            return isSuccessfull;
        }

        public static bool checkValidityOfSides(T a, T b, T c)
        {
            bool isValid = false;
            float x, y, z;
            // Check if we are getting something that can be converted to float since it will be valid for both float and int
            if (float.TryParse(a.ToString(), out x) && float.TryParse(b.ToString(), out y) && float.TryParse(c.ToString(), out z))
            {
                // Check for valid length of sides
                if (((x + y) > z) && ((x + z) > y) && ((y + z) > x))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
