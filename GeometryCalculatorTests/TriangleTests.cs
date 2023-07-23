using GeometryCalculations.Models;
using GeometryCalculations.Services;

namespace GeometryCalculatorTests;

[TestFixture]
public class TriangleTests
{
    [Test]
    public void CreateTriangle_NegativeSideA_ThrowsArgumentException()
    {
        // Arrange
        double sideA = -2;
        double sideB = 5;
        double sideC = 6;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => new Triangle(sideA, sideB, sideC));
    }

    
    [Test]
    public void CreateTriangle_ZeroSideA_ThrowsArgumentException()
    {
        // Arrange
        double sideA = 0;
        double sideB = 2;
        double sideC = 5;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => new Triangle(sideA, sideB, sideC));
    }

    
    [Test]
    public void CreateTriangle_ImpossibleTriangle_ThrowsArgumentException()
    {
        // Arrange
        double sideA = 1;
        double sideB = 2;
        double sideC = 5;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => new Triangle(sideA, sideB, sideC));
    }
    
    
    [Test]
    public void CalculateArea_Triangle_ReturnsCorrectArea()
    {
        // Arrange
        double sideA = 4;
        double sideB = 2;
        double sideC = 5;
        Triangle triangle = new Triangle(sideA, sideB, sideC);
        var geometryCalculator = new GeometryCalculator();

        // Act
        double area = geometryCalculator.CalculateArea(triangle);

        // Assert
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        double expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        Assert.That(area, Is.EqualTo(expectedArea).Within(0.001));
    }
    
    
    [Test]
    public void Check_RightAngledTriangle_ReturnsCorrectArea()
    {
        // Arrange
        double sideA = 6;
        double sideB = 8;
        double sideC = 10;
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        bool isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.That(isRightAngled, Is.True);
    }
    
    
    [Test]
    public void CheckRightAngled_NotRightAngledTriangle_ReturnsCorrectArea()
    {
        // Arrange
        double sideA = 7;
        double sideB = 8;
        double sideC = 10;
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        bool isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.That(isRightAngled, Is.False);
    }
}