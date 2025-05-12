using Microsoft.AspNetCore.Mvc;
using SuperSoccer.Models.Requests;

namespace SuperSoccer.Controllers
{
    [Route("/api/v1/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController (ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// [POST] - Generates Super Soccer 
        /// </summary>
        /// <remarks>
        /// Generates team of 5 players from specified universe and in specified formation (Goalie - Attackers - Defenders)
        /// </remarks>
        /// <param name="request">Request object that contain Team Name, UniverseType[0 - StarWars, 1 - Pokemon], NumberOfAttackers, NumberOfDefenders</param>
        /// <returns>Generated team with assigned players based on formation</returns>
        [HttpPost]
        [Route("generate")]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<Team>> Post([FromBody] PostTeamRequest request)
        {
            //Validating formation.
            //There shouldn't be less than 0 attackers or 0 defenders.
            //There shouldn't be a formation that has more or less than 4 field players.
            if (request.NumberOfAttackers < 0 
                || request.NumberOfDefenders < 0 
                || request.NumberOfAttackers + request.NumberOfDefenders != 4)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "400 Bad Request - Unsupported formation",
                    Detail = $"The sum of the attackers and defenders is not equal to 4 or negative values were provided",
                    Status = StatusCodes.Status400BadRequest
                });
            }

            var team = await _teamService.GenerateTeam(request.Universe, request.Name, request.NumberOfAttackers, request.NumberOfDefenders);

            return Ok(team);
        }
    }
}
