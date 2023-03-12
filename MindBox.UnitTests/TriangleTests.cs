using System;
using MindBox.Core.Models;
using NUnit.Framework;

namespace MindBox.UnitTests;

public class TriangleTests
{
    private const double Delta = 0.01;

    [Test]
    public void TestCalculateArea()
    {
        Triangle triangle = new Triangle(6.6, 11.2, 13);
        double expectedArea = 36.96d;

        // Act
        double area = triangle.CalculateArea();

        // Assert
        Assert.AreEqual(expectedArea, area, Delta);
    }

    [Test]
    public void TestIsRightAngle()
    {
        // Arrange
        double sideA = 3;
        double sideB = 4;
        double sideC = 5;
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        bool isRightAngle = triangle.IsRightAngle();

        // Assert
        Assert.IsTrue(isRightAngle);
    }

    [Test]
    public void TestIsNotRightAngle()
    {
        // Arrange
        double sideA = 2;
        double sideB = 2;
        double sideC = 3;
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        bool isRightAngle = triangle.IsRightAngle();

        // Assert
        Assert.IsFalse(isRightAngle);
    }

    [Test]
    public void TestTriangleSides()
    {
        // Arrange
        double sideA = 1.2;
        double sideB = 1.8;
        double sideC = 2.1;
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        double actualSideA = triangle.SideA;
        double actualSideB = triangle.SideB;
        double actualSideC = triangle.SideC;

        // Assert
        Assert.AreEqual(sideA, actualSideA);
        Assert.AreEqual(sideB, actualSideB);
        Assert.AreEqual(sideC, actualSideC);
    }

    [Test]
    public void Triangle_WithSmallSideLengths_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        double sideA = 0.9E-70;
        double sideB = 1.0;
        double sideC = 1.0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideB, sideA, sideC));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideC, sideB, sideA));
    }

    [Test]
    public void Triangle_WithBigSideLengths_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        double sideA = 1.1E+70;
        double sideB = 1E+70;
        double sideC = 1E+70;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideB, sideA, sideC));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideC, sideB, sideA));
    }

    [Test]
    public void Triangle_WithMaximumSideLengths_DoesNotThrowException()
    {
        // Arrange
        double side = Triangle.MaxSide;

        // Act & Assert
        Assert.DoesNotThrow(() => new Triangle(side, side, side));
    }

    [Test]
    public void Triangle_WithMinimumSideLengths_DoesNotThrowException()
    {
        // Arrange
        double side = Triangle.MinSide;

        // Act & Assert
        Assert.DoesNotThrow(() => new Triangle(side, side, side));
    }
}