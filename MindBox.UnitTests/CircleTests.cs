using System;
using MindBox.Core.Models;
using NUnit.Framework;

namespace MindBox.UnitTests;

[TestFixture]
public class CircleTests
{
    private const double Delta = 0.01;
    
    [Test]
    public void CalculateArea_CircleWithMaxRadius_ReturnsExpectedResult()
    {
        // Arrange
        double maxRadius = 7E+153;
        Circle circle = new Circle(maxRadius);
        double expectedArea = 1.5393804002589985E+308;

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea, area, Delta);
    }

    [Test]
    public void CalculateArea_CircleWithMinRadius_ReturnsExpectedResult()
    {
        // Arrange
        double minRadius = 7E-153;
        Circle circle = new Circle(minRadius);
        double expectedArea = 1.5393804002589985E-304;

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea, area, Delta);
    }

    [Test]
    public void Circle_Constructor_ThrowsArgumentOutOfRangeException_ForRadiusGreaterThanMaxRadius()
    {
        // Arrange
        double radius = Circle.MaxRadius * 2;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [Test]
    public void Circle_Constructor_ThrowsArgumentOutOfRangeException_ForRadiusLessThanMinRadius()
    {
        // Arrange
        double radius = Circle.MinRadius / 2;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }
    
    [Test]
    public void CalculateArea_ReturnsCorrectArea_ForCircleWithRadius_5()
    {
        // Arrange
        double radius = 5;
        Circle circle = new Circle(radius);
        double expectedArea = 78.54d;
        
        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea, area, Delta);
    }
    
    [Test]
    public void CalculateArea_ReturnsCorrectArea_ForCircleWithRadius_12_5()
    {
        // Arrange
        double radius = 12.5;
        Circle circle = new Circle(radius);
        double expectedArea = 490.87d;

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea , area, Delta);
    }
    
    [Test]
    public void TestCircleRadius()
    {
        // Arrange
        double radius = 2.2;
        Circle circle = new Circle(radius);

        // Act
        double actualRadius = circle.Radius;

        // Assert
        Assert.AreEqual(radius, actualRadius);
    }
}