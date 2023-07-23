using GeometryCalculations.Models;
using GeometryCalculations.Services;

namespace GeometryCalculatorTests;

[TestFixture]
public class CircleTests
{
    [Test]
    public void CreateCircle_NegativeRadius_ThrowsArgumentException()
    {
        // Arrange
        double radius = -2;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    
    [Test]
    public void CreateCircle_ZeroRadius_ThrowsArgumentException()
    {
        // Arrange
        double radius = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }
    
    
    [Test]
    public void CalculateArea_PositiveRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5;
        Circle circle = new Circle(radius);
        var geometryCalculator = new GeometryCalculator();

        // Act
        double area = geometryCalculator.CalculateArea(circle);

        // Assert
        double expectedArea = Math.PI * radius * radius;
        Assert.That(area, Is.EqualTo(expectedArea).Within(0.001));
    }
}