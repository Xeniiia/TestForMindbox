using GeometryCalculations.Models;
using GeometryCalculations.Services;

namespace GeometryCalculatorTests;

[TestFixture]
public class GeometryCalculatorTests
{
    [Test]
    public void CalculateArea_Circle_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5;
        Circle circle = new Circle(radius);
        GeometryCalculator calculator = new GeometryCalculator();

        // Act
        double area = calculator.CalculateArea(circle);

        // Assert
        double expectedArea = Math.PI * radius * radius;
        Assert.That(area, Is.EqualTo(expectedArea).Within(0.001));
    }

    [Test]
    public void CalculateArea_Triangle_ReturnsCorrectArea()
    {
        // Arrange
        double sideA = 3;
        double sideB = 4;
        double sideC = 5;
        Triangle triangle = new Triangle(sideA, sideB, sideC);
        GeometryCalculator calculator = new GeometryCalculator();

        // Act
        double area = calculator.CalculateArea(triangle);

        // Assert
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        double expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        Assert.That(area, Is.EqualTo(expectedArea).Within(0.001));
    }
    
    [Test]
    public void CalculateArea_MultipleShapes_ReturnsCorrectAreas()
    {
        // Arrange
        Circle circle = new Circle(5);
        Triangle triangle = new Triangle(3, 4, 5);

        GeometryCalculator calculator = new GeometryCalculator();

        // Act
        double circleArea = calculator.CalculateArea(circle);
        double triangleArea = calculator.CalculateArea(triangle);

        // Assert
        double expectedCircleArea = Math.PI * 5 * 5;
        double expectedTriangleArea = 6;

        Assert.That(circleArea, Is.EqualTo(expectedCircleArea).Within(0.001));
        Assert.That(triangleArea, Is.EqualTo(expectedTriangleArea).Within(0.001));
    }
}