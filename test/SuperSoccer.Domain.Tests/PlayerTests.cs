namespace SuperSoccer.Domain.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void CalculatePower_ReturnsCorrectAverageOfHeightAndWeight()
        {
            // Arrange
            var player = new Player
            {
                ExternalId = 1,
                Name = "Test Jedi",
                Height = 180,
                Weight = 80,
                Universe = UniverseType.StarWars
            };

            // Act
            var result = player.CalculatePower();

            // Assert
            var expected = Math.Round((180 + 80) / 2.0, 1); // 130.0
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatePower_WithZeroValues_ReturnsZero()
        {
            // Arrange
            var player = new Player
            {
                ExternalId = 2,
                Name = "R2-D2",
                Height = 0,
                Weight = 0,
                Universe = UniverseType.StarWars
            };

            // Act
            var result = player.CalculatePower();

            // Assert
            Assert.Equal(0.0, result);
        }
    }
}