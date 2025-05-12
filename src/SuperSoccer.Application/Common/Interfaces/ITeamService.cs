using SuperSoccer.Domain.Entities;

namespace SuperSoccer.Application.Common.Interfaces
{
    public interface ITeamService
    {
        public Task<Team> GenerateTeam(UniverseType universeType, string name, int attackers, int defenders);
    }
}
