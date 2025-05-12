namespace SuperSoccer.Application.Common.Interfaces
{
    public interface IUniverseProcessor
    {
        Task<Player?> GetPlayerById(UniverseType universe, int id);
        Task<List<Player>> GetSquad(UniverseType universe);
    }
}
