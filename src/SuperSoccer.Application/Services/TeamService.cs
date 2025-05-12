using SuperSoccer.Domain.Entities;

namespace SuperSoccer.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUniverseProcessor _universeProcessor;

        public TeamService(IUniverseProcessor universeProcessor)
        {
            _universeProcessor = universeProcessor;
        }

        public async Task<Team> GenerateTeam(UniverseType universeType, string name, int attackers, int defenders)
        {
            var teamToReturn = new Team
            {
                Id = Guid.NewGuid(),
                Name = name,
                Universe = universeType,
                Players = new List<AssignedPlayer>()
            };

            var team = await _universeProcessor.GetSquad(universeType);

            //Setting Goalie
            team = team.OrderBy(player => player.Height).ToList();
            teamToReturn.Players.Add(new AssignedPlayer
            {
                Id = team.Last().Id,
                ExternalId = team.Last().ExternalId,
                Name = team.Last().Name,
                Weight = team.Last().Weight,
                Height = team.Last().Height,
                Power = team.Last().Power,
                Universe = universeType,
                Position = PlayerType.Goalie
            });

            team.RemoveAt(team.Count-1);
            //Setting Attackers
            if (attackers > 0)
            {
                for (int i = 0; i < attackers; i++)
                {
                    teamToReturn.Players.Add(new AssignedPlayer
                    {
                        Id = team.First().Id,
                        ExternalId = team.First().ExternalId,
                        Name = team.First().Name,
                        Weight = team.First().Weight,
                        Height = team.First().Height,
                        Power = team.First().Power,
                        Universe = universeType,
                        Position = PlayerType.Offence
                    });
                    team.RemoveAt(0);
                }
            }

            //Setting Defenders
            if (defenders > 0)
            {
                team = team.OrderByDescending(player => player.Weight).ToList();
                for (int i = 0; i < defenders; i++)
                {
                    teamToReturn.Players.Add(new AssignedPlayer
                    {
                        Id = team.First().Id,
                        ExternalId = team.First().ExternalId,
                        Name = team.First().Name,
                        Weight = team.First().Weight,
                        Height = team.First().Height,
                        Power = team.First().Power,
                        Universe = universeType,
                        Position = PlayerType.Defence
                    });
                    team.RemoveAt(0);
                }
            }

            //Calculate Soccer Team power
            teamToReturn.SoccerTeamPower = TeamPowerCalculator.CalculateTeamPower(teamToReturn.Players);

            return teamToReturn;


        }

    }
}
