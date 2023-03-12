namespace MindBox.Core.Models;

public class Triangle : IShape
{
    // The maximum and minimum values for the sides of a triangle were chosen to avoid overflowing during calculations
    // and to prevent side lengths from being too small and approaching zero, which could lead to incorrect results.
    public const double MaxSide = 1E+70;
    public const double MinSide = 1E-70;
    
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA < MinSide || sideB < MinSide || sideC < MinSide)
        {
            throw new ArgumentOutOfRangeException($"Side lengths must be greater than {MinSide}.");
        }
        
        if (sideA > MaxSide || sideB > MaxSide || sideC > MaxSide)
        {
            throw new ArgumentOutOfRangeException($"Side lengths must be greater than {MaxSide}.");
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException("The lengths of the sides do not form a triangle.");
        }
        
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        double semiPerimeter = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    public bool IsRightAngle()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);

        return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
    }
}