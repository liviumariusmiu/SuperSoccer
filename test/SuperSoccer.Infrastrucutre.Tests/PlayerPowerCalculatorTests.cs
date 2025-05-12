namespace SuperSoccer.Infrastrucutre.Tests
{
    public class PlayerPowerCalculatorTests
    {
        [Theory]
        [InlineData(180.0, 80.0, 130.0)]
        [InlineData(170.5, 60.5, 115.5)]
        [InlineData(150.2, 49.8, 100.0)]
        public void CalculatePlayerPower_ValidInputs_ReturnsCorrectAverage(double height, double weight, double expected)
        {
            // Act
            var result = PlayerPowerCalculator.CalculatePlayerPower(height, weight);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatePlayerPower_ZeroValues_ReturnsZero()
        {
            // Act
            var result = PlayerPowerCalculator.CalculatePlayerPower(0.0, 0.0);

            // Assert
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void CalculatePlayerPower_NegativeValues_ReturnsCorrectAverage()
        {
            // Act
            var result = PlayerPowerCalculator.CalculatePlayerPower(-100.0, 50.0);

            // Assert
            Assert.Equal(-25.0, result);
        }
    }
}
