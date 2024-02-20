using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal abstract class Shape
    {
        public Int64 Color {
            get {
                int x;
                switch (_color)
                {
                    case 100255000000:
                        {
                            x = 1;
                            break;
                        }
                    case 100000255000:
                        {
                            x = 2;
                            break;
                        }
                    case 100000000255:
                        {
                            x = 3;
                            break;
                        }
                    default:
                        {
                            x = 0;
                            break;
                        }
                }
                return x; 
            }
            set {
                switch (value)
                {
                    case 1:
                    {
                         /*
                          * We are using 100 opacity on all of them and the RGB(Red, Green, Blue) Format.
                          * Example:
                          *     For red we would have 100(Opacity) + 255(Red) + 000(Green) + 000(Blue) = 100255000000
                          */
                        _color = 100255000000;
                        break;
                    }
                    case 2:
                    {
                        _color = 100000255000;
                        break;
                    }
                    case 3:
                    {
                        _color = 100000000255;
                        break;
                    }
                    default:
                        {
                            _color = 0;
                            break;
                        }

                } 
            } 
        }
        private Int64 _color;
        public abstract double perimeter();
        public abstract double area();

        static class RGB
        {
            private static double red = 1;
            private static double green = 2;
            private static double blue = 3;
        } 
    }
}
