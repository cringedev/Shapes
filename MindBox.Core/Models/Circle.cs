namespace MindBox.Core.Models;

public class Circle : IShape
{
    // The CalculateArea method returns the area of a circle in double data type, which has a maximum value of
    // 1.7976931348623157E+308 (double.MaxValue). To avoid the possibility of an overflow exception, we limit the
    // maximum radius that can be used in the calculation. The maximum radius is calculated using the formula:
    // MaxRadius = Math.Sqrt(Double.MaxValue / Math.PI) = 7.5645455722826181E+153
    // For convenience, we use the value 7E+153 as the maximum radius. Attempting to calculate the area of a circle with
    // a larger radius will result in an ArgumentOutOfRangeException.
    public const double MaxRadius = 7E+153;

    // The smallest positive value that can be represented by the double data type is 4.9406564584124654E-324
    // (double.Epsilon). However, due to squaring this number when calculating the area, we can end up with an area of
    // zero. To avoid this, we set the minimum radius to a very small positive value of 7E-153, which ensures that the
    // area will always be a positive number. Attempting to create a circle with a radius smaller than this value will
    // result in an ArgumentOutOfRangeException.
    public const double MinRadius = 7E-153;

    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius < MinRadius)
        {
            throw new ArgumentOutOfRangeException(nameof(radius),
                $"The radius cannot be less than {MinRadius}");
        }

        if (radius > MaxRadius)
        {
            throw new ArgumentOutOfRangeException(nameof(radius),
                $"The radius cannot be greater than {MaxRadius}.");
        }

        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}