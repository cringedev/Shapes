using System;
using MindBox.Core.Models;
using NUnit.Framework;

namespace MindBox.UnitTests;

[TestFixture]
public class CircleTests
{
    private const double Delta = 0.01;
    
    [Test]
    [TestCase(5, 78.54d)]
    [TestCase(12.5, 490.87d)]
    [TestCase(7E+153, 1.5393804002589985E+308)]
    [TestCase(7E-153, 1.5393804002589985E-304)]
    public void CalculateArea_ReturnsCorrectArea_ForCircleWithRadius(double radius, double expectedArea)
    {
        // Arrange
        Circle circle = new Circle(radius);

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea, area, Delta);
    }
    
    [Test]
    [TestCase(0)]
    [TestCase(double.MaxValue)]
    [TestCase(double.Epsilon)]
    [TestCase(double.MinValue)]
    [TestCase(Circle.MaxRadius * 2)]
    [TestCase(Circle.MinRadius / 2)]
    public void Constructor_ThrowsException_WhenRadiusIsOutOfRange(double radius)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [Test]
    [TestCase(2.2)]
    [TestCase(10)]
    [TestCase(Circle.MaxRadius)]
    [TestCase(Circle.MinRadius)]
    public void Radius_ReturnsExpectedValue(double radius)
    {
        // Arrange
        Circle circle = new Circle(radius);

        // Act
        double actualRadius = circle.Radius;

        // Assert
        Assert.AreEqual(radius, actualRadius);
    }
}