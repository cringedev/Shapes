using System;
using MindBox.Core.Models;
using NUnit.Framework;

namespace MindBox.UnitTests;

[TestFixture]
public class TriangleTests
{
    private const double Delta = 0.01;

    [Test]
    [TestCase(3, 4, 5, 6)]
    [TestCase(6.6, 11.2, 13, 36.96d)]
    [TestCase(Triangle.MaxSide, Triangle.MaxSide, Triangle.MaxSide, 4.330127018922195E+139d)]
    [TestCase(Triangle.MinSide, Triangle.MinSide, Triangle.MinSide, 4.3301270189221943E-141d)]
    public void CalculateArea_ReturnsCorrectArea_ForTriangleWithSides(double a, double b, double c, double expectedArea)
    {
        // Arrange
        Triangle triangle = new Triangle(a, b, c);

        // Act
        double area = triangle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea, area, Delta);
    }
    
    [Test]
    [TestCase(Triangle.MinSide)]
    [TestCase(Triangle.MaxSide)]
    public void Constructor_DoesNotThrowException_ForMinMaxSides(double side)
    {
        // Act & Assert
        Assert.DoesNotThrow(() => new Triangle(side, side, side));
    }
    
    [Test]
    [TestCase(3, 4, 5)]
    [TestCase(1.2, 1.8, 2.1)]
    [TestCase(Triangle.MaxSide, Triangle.MaxSide, Triangle.MaxSide)]
    [TestCase(Triangle.MinSide, Triangle.MinSide, Triangle.MinSide)]
    public void Constructor_SetsTriangleSidesCorrectly(double a, double b, double c)
    {
        // Arrange & Act
        Triangle triangle = new Triangle(a, b, c);

        // Assert
        Assert.AreEqual(a, triangle.SideA);
        Assert.AreEqual(b, triangle.SideB);
        Assert.AreEqual(c, triangle.SideC);
    }
    
    [Test]
    [TestCase(0.9E-70, 1.0)]
    [TestCase(1.1E+70, 1E+70)]
    public void Constructor_ThrowsArgumentOutOfRangeException_ForInvalidSides(double invalidSideLength,
        double validSideLength)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Triangle(invalidSideLength, validSideLength, validSideLength));
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Triangle(validSideLength, invalidSideLength, validSideLength));
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Triangle(validSideLength, validSideLength, invalidSideLength));
    }
    
    [Test]
    [TestCase(3, 4, 5, true)]
    [TestCase(5, 12, 13, true)]
    [TestCase(2, 2, 3, false)]
    public void IsRightAngle_ReturnsCorrectValue_ForValidTriangle(double a, double b, double c, bool expected)
    {
        // Arrange
        Triangle triangle = new Triangle(a, b, c);

        // Act
        bool isRightAngle = triangle.IsRightAngle();

        // Assert
        Assert.AreEqual(expected, isRightAngle);
    }
}