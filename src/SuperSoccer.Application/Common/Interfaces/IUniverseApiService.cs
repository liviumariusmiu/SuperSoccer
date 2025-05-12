using SuperSoccer.Domain.Entities;

namespace SuperSoccer.Application.Common.Interfaces
{
    public interface IUniverseApiService
    {
        /// <summary>
        /// Get Super Soccer Player by ID 
        /// </summary>
        /// <param name="id">Super Soccer Player identifier</param>
        /// <returns>Returns Player entity</returns>
        public Task<Player?> GetPlayerById(int id);

        /// <summary>
        /// Get team of 5 players from the Universe
        /// </summary>
        /// <returns>List of 5 Player entities</returns>
        public Task<List<Player>> GetSquad();
    }
}
