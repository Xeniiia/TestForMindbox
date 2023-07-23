namespace GeometryCalculations.Models;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("The radius must be a positive number", nameof(radius));
        }
        
        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}