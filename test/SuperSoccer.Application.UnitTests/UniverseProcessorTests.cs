using Moq;

namespace SuperSoccer.Application.UnitTests
{
    public class UniverseProcessorTests
    {
        [Fact]
        public async Task GetPlayerById_ReturnsExpectedPlayer()
        {
            // Arrange
            var universe = UniverseType.Pokemon;
            var playerId = 42;
            var expectedPlayer = new Player
            {
                Id = Guid.NewGuid(),
                ExternalId = playerId,
                Name = "Pikachu",
                Height = 185,
                Weight = 90,
                Power = 95,
                Universe = universe
            };

            var apiServiceMock = new Mock<IUniverseApiService>();
            apiServiceMock.Setup(x => x.GetPlayerById(playerId)).ReturnsAsync(expectedPlayer);

            var universeFactoryMock = new Mock<Func<UniverseType, IUniverseApiService>>();
            universeFactoryMock.Setup(f => f(universe)).Returns(apiServiceMock.Object);

            var processor = new UniverseProcessor(universeFactoryMock.Object);

            // Act
            var result = await processor.GetPlayerById(universe, playerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPlayer.ExternalId, result!.ExternalId);
            Assert.Equal(expectedPlayer.Name, result.Name);
        }

        [Fact]
        public async Task GetSquad_ReturnsExpectedPlayers()
        {
            // Arrange
            var universeType = UniverseType.StarWars;
            var expectedPlayers = new List<Player>
            {
                new() { Id = Guid.NewGuid(), ExternalId = 1, Name = "Obi-Wan", Height = 200, Weight = 90, Power = 10, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 2, Name = "Luke", Height = 190, Weight = 95, Power = 9, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 3, Name = "Yoda", Height = 180, Weight = 85, Power = 8, Universe = universeType },
                new() { Id = Guid.NewGuid(), ExternalId = 4, Name = "Palpatine", Height = 175, Weight = 80, Power = 7, Universe = universeType},
                new() { Id = Guid.NewGuid(), ExternalId = 5, Name = "Jaba", Height = 170, Weight = 70, Power = 6, Universe = universeType}
            };

            var apiServiceMock = new Mock<IUniverseApiService>();
            apiServiceMock.Setup(x => x.GetSquad()).ReturnsAsync(expectedPlayers);

            var universeFactoryMock = new Mock<Func<UniverseType, IUniverseApiService>>();
            universeFactoryMock.Setup(f => f(universeType)).Returns(apiServiceMock.Object);

            var processor = new UniverseProcessor(universeFactoryMock.Object);

            // Act
            var result = await processor.GetSquad(universeType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
            Assert.Contains(result, p => p.Name == "Luke");
        }
    }
}
