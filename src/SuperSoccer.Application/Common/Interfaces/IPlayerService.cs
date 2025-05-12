using SuperSoccer.Domain.Entities;

namespace SuperSoccer.Application.Common.Interfaces
{
    internal interface IPlayerService
    {
        public List<Player> GetAllPlayers();
        public Player GetPlayerById(int id);
        public Player CreateNewPlayer(Player player);
    }
}
