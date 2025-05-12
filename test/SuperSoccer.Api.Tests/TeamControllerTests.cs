using Microsoft.AspNetCore.Mvc;
using Moq;
using SuperSoccer.Application.Common.Interfaces;
using SuperSoccer.Controllers;
using SuperSoccer.Domain.Entities;
using SuperSoccer.Domain.Enums;
using SuperSoccer.Models.Requests;

namespace SuperSoccer.Api.Tests
{
    public class TeamControllerTests
    {
        private readonly Mock<ITeamService> _mockTeamService;
        private readonly TeamController _controller;

        public TeamControllerTests()
        {
            _mockTeamService = new Mock<ITeamService>();
            _controller = new TeamController(_mockTeamService.Object);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_WhenInvalidFormation()
        {
            // Arrange
            var request = new PostTeamRequest
            {
                Name = "Test Team",
                Universe = UniverseType.Pokemon,
                NumberOfAttackers = 2,
                NumberOfDefenders = 3 // invalid total: 5
            };

            // Act
            var result = await _controller.Post(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var problemDetails = Assert.IsType<ProblemDetails>(badRequestResult.Value);
            Assert.Equal(400, problemDetails.Status);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WithGeneratedTeam()
        {
            // Arrange
            var request = new PostTeamRequest
            {
                Name = "Test Team",
                Universe = UniverseType.Pokemon,
                NumberOfAttackers = 2,
                NumberOfDefenders = 2
            };

            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Universe = request.Universe,
                Players = new List<AssignedPlayer>(),
                SoccerTeamPower = 100
            };

            _mockTeamService
                .Setup(service => service.GenerateTeam(request.Universe, request.Name, request.NumberOfAttackers, request.NumberOfDefenders))
                .ReturnsAsync(team);

            // Act
            var result = await _controller.Post(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTeam = Assert.IsType<Team>(okResult.Value);
            Assert.Equal(team.Name, returnedTeam.Name);
            Assert.Equal(team.Universe, returnedTeam.Universe);
        }
    }
}