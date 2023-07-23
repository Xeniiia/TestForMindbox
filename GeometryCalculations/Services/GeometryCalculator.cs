using GeometryCalculations.Models;

namespace GeometryCalculations.Services;

public class GeometryCalculator
{
    public double CalculateArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}