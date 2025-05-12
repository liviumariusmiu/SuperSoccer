using Moq;

namespace SuperSoccer.Application.UnitTests
{
    public class TeamServiceTests
    {
        [Fact]
        public async Task GenerateTeam_ReturnsValidTeam_WithCorrectPlayersAndPower()
        {
            // Arrange
            var universeType = UniverseType.StarWars;
            var name = "Test Team";
            int attackers = 2;
            int defenders = 2;
            double expectedPower = 40;

            var mockPlayers = new List<Player>
            {
                new() { Id = Guid.NewGuid(), ExternalId = 1, Name = "Obi-Wan", Height = 200, Weight = 90, Power = 10, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 2, Name = "Luke", Height = 190, Weight = 95, Power = 9, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 3, Name = "Yoda", Height = 180, Weight = 85, Power = 8, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 4, Name = "Palpatine", Height = 175, Weight = 80, Power = 7, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 5, Name = "Jaba", Height = 170, Weight = 70, Power = 6, Universe = universeType}
            };

            var universeProcessorMock = new Mock<IUniverseProcessor>();
            universeProcessorMock.Setup(x => x.GetSquad(universeType))
                .ReturnsAsync(mockPlayers);

            var service = new TeamService(universeProcessorMock.Object);

            // Act
            var result = await service.GenerateTeam(universeType, name, attackers, defenders);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(universeType, result.Universe);
            Assert.Equal(5, result.Players.Count);

            //Verify Goalie 
            Assert.Equal(PlayerType.Goalie, result.Players[0].Position);
            Assert.Equal(mockPlayers[0].Height, result.Players[0].Height); //200

            //Verify Attackers 
            Assert.Equal(PlayerType.Offence, result.Players[1].Position);
            Assert.Equal(mockPlayers[4].Height, result.Players[1].Height); //170
            Assert.Equal(PlayerType.Offence, result.Players[2].Position);
            Assert.Equal(mockPlayers[3].Height, result.Players[2].Height); //175

            //Verify Defenders
            Assert.Equal(PlayerType.Defence, result.Players[3].Position);
            Assert.Equal(mockPlayers[1].Weight, result.Players[3].Weight); //95
            Assert.Equal(PlayerType.Defence, result.Players[4].Position);
            Assert.Equal(mockPlayers[2].Weight, result.Players[4].Weight); //85

            //Verify power
            Assert.Equal(expectedPower, result.SoccerTeamPower);
        }
    }
}