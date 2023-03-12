using MindBox.Core;
using MindBox.Core.Models;

//This code allows you to calculate the areas of various shapes without knowing their types at compile-time.
//The list of shapes is defined using the interface IShape, which is implemented by the classes Circle and Triangle.
//The CalculateArea() method is called on each shape in the list, and the areas are summed up to get the total area.
//Finally, the total area is printed to the console using Console.WriteLine().

List<IShape> shapes = new List<IShape>();
shapes.Add(new Triangle(10, 10, 10));
shapes.Add(new Circle(4));

double totalArea = 0;
foreach (IShape shape in shapes)
{
    totalArea += shape.CalculateArea();
}

Console.WriteLine($"Total area: {totalArea:F2}");
Console.ReadLine();