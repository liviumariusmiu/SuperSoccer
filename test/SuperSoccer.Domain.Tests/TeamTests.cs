namespace SuperSoccer.Domain.Tests
{
    public class TeamTests
    {
        [Fact]
        public void CalculatePower_ReturnsCorrectSumOfPlayerPowers()
        {
            // Arrange
            var universeType = UniverseType.StarWars;
            var team = new Team
            {
                Name = "The Legends",
                Universe = UniverseType.StarWars,
                Players = new List<AssignedPlayer>
                {
                    new() { Id = Guid.NewGuid(), ExternalId = 1, Name = "Obi-Wan", Height = 200, Weight = 90, Power = 10, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 2, Name = "Luke", Height = 190, Weight = 95, Power = 9, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 3, Name = "Yoda", Height = 180, Weight = 85, Power = 8, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 4, Name = "Palpatine", Height = 175, Weight = 80, Power = 7, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 5, Name = "Jaba", Height = 170, Weight = 70, Power = 6, Universe = universeType}
                }
            };

            var expected = Math.Round(team.Players.Sum(player => player.Power), 1);

            // Act
            var result = team.CalculatePower();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatePower_EmptyTeam_ReturnsZero()
        {
            // Arrange
            var team = new Team
            {
                Name = "Empty Squad",
                Universe = UniverseType.StarWars,
                Players = new List<AssignedPlayer>()
            };

            // Act
            var result = team.CalculatePower();

            // Assert
            Assert.Equal(0.0, result);
        }
    }
}
