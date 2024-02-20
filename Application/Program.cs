// See https://aka.ms/new-console-template for more information
using Application;

Square square = new Square(3);
Console.WriteLine("Square:");
Console.WriteLine("area: " + square.area());
Console.WriteLine("perimeter: " + square.perimeter());
Console.WriteLine("isOval: " + square.isOval());
Console.WriteLine("static realization of area: " + Square.getAreaWithoutInstance(8));
// Set color of square
square.Color = 1;
Console.WriteLine("Color of square is: " + square.Color);
Rectangle rectangle = new Rectangle(2, 4);
Console.WriteLine("\nRectangle:");
Console.WriteLine("area: " + rectangle.area());
Console.WriteLine("perimeter: " + rectangle.perimeter());
Console.WriteLine("isOval: " + rectangle.isOval());
// Set color of rectangle
rectangle.Color = 2;
Console.WriteLine("Color of square is: " + rectangle.Color);
Circle circle = new Circle(0.77);
Console.WriteLine("\nCircle:");
Console.WriteLine("area: " + circle.area());
Console.WriteLine("perimeter: " + circle.perimeter());
Console.WriteLine("isOval: " + circle.isOval());
// Set color of circle
circle.Color = 3;
Console.WriteLine("Color of square is: " + circle.Color);
Triangle<int> intTriangle;
String typeOfDataForIntTriangle;
bool successInt = Triangle<int>.getInstance(3, 4, 5,out intTriangle, out typeOfDataForIntTriangle);
if (successInt)
{
    Console.WriteLine("\nFloat Triangle:");
    Console.WriteLine("Successfully created a triangle");
    Console.WriteLine("area: " + intTriangle.area());
    Console.WriteLine("perimeter: " + intTriangle.perimeter());
    Console.WriteLine("isOval: " + intTriangle.isOval());
    Console.WriteLine("Type of data: " + typeOfDataForIntTriangle);
    //Set triangle color
    intTriangle.Color = 2;
    Console.WriteLine("Color: " + intTriangle.Color);
}
Triangle<float> floatTriangle;
String typeOfDataForFloatTriangle;
bool successFloat = Triangle<float>.getInstance(3.5f, 4.5f, 5.5f,out floatTriangle, out typeOfDataForFloatTriangle);
if (successFloat)
{
    Console.WriteLine("\nFloat Triangle:");
    Console.WriteLine("Successfully created a triangle");
    Console.WriteLine("area: " + floatTriangle.area());
    Console.WriteLine("perimeter: " + floatTriangle.perimeter());
    Console.WriteLine("isOval: " + floatTriangle.isOval());
    Console.WriteLine("Type of data: " + typeOfDataForFloatTriangle);
    //Set triangle color
    floatTriangle.Color = 1;
    Console.WriteLine("Color: " + floatTriangle.Color);

}




