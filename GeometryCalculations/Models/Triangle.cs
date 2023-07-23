namespace GeometryCalculations.Models;

public class Triangle : Shape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new InvalidOperationException("The lengths of the sides of a triangle must be positive numbers");
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new InvalidOperationException("It is not possible to create a triangle with given sides");
        }

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    
    public override double CalculateArea()
    {
        double semiPerimeter = (_sideA + _sideB + _sideC) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }

    
    public bool IsRightAngled()
    {
        double aSquared = _sideA * _sideA;
        double bSquared = _sideB * _sideB;
        double cSquared = _sideC * _sideC;
        
        var tolerance = 0.000000001;
        return Math.Abs(aSquared + bSquared - cSquared) < tolerance || 
               Math.Abs(aSquared + cSquared - bSquared) < tolerance || 
               Math.Abs(bSquared + cSquared - aSquared) < tolerance;
    }
}