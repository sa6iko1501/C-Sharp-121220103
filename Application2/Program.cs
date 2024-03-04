// See https://aka.ms/new-console-template for more information
using Application2;

Console.WriteLine("Hello! Which task would you like to run?\n");
Console.WriteLine("1.Coordinates task.");
Console.WriteLine("2.Personal Info task.");
String x = Console.ReadLine();
switch (x)
{
    case "1":
        {
            MapCoordinatesParser parser = new MapCoordinatesParser();
            Console.WriteLine("Successfully executed task #1");
            break;
        }
    case "2":
        {
            PersonalInfoParser parser = new PersonalInfoParser();
            Console.WriteLine("Sucessfully executed task #2");
            break;
        }
}

