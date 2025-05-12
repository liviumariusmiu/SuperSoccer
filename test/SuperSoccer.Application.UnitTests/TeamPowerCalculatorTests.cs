using SuperSoccer.Application.Utils;
using SuperSoccer.Domain.Enums;

namespace SuperSoccer.Application.UnitTests
{
    public class TeamPowerCalculatorTests
    {
        [Fact]
        public void CalculateTeamPower_ReturnsCorrectRoundedSum()
        {
            UniverseType universeType = UniverseType.StarWars;

            // Arrange
            var players = new List<AssignedPlayer>
            {
                new() { Id = Guid.NewGuid(), ExternalId = 1, Name = "Obi-Wan", Height = 200, Weight = 90, Power = 10, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 2, Name = "Luke", Height = 190, Weight = 95, Power = 9, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 3, Name = "Yoda", Height = 180, Weight = 85, Power = 8, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 4, Name = "Palpatine", Height = 175, Weight = 80, Power = 7, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 5, Name = "Jaba", Height = 170, Weight = 70, Power = 6, Universe = universeType}
            };

            var expectedPower = Math.Round(players.Sum(p => p.Power), 1); // = 225.6

            // Act
            var result = TeamPowerCalculator.CalculateTeamPower(players);

            // Assert
            Assert.Equal(expectedPower, result);
        }

        [Fact]
        public void CalculateTeamPower_EmptyList_ReturnsZero()
        {
            // Arrange
            var players = new List<AssignedPlayer>();

            // Act
            var result = TeamPowerCalculator.CalculateTeamPower(players);

            // Assert
            Assert.Equal(0.0, result);
        }

    }
}
