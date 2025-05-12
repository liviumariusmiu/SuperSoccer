namespace SuperSoccer.Application.Services
{
    public class UniverseProcessor : IUniverseProcessor
    {
        private readonly Func<UniverseType, IUniverseApiService> _universeFactory;

        public UniverseProcessor(Func<UniverseType, IUniverseApiService> universeFactory)
        {
            _universeFactory = universeFactory;
        }

        public async Task<Player?> GetPlayerById(UniverseType universe, int id)
        {
            var service = _universeFactory(universe);
            return await service.GetPlayerById(id);
        }

        public async Task<List<Player>> GetSquad(UniverseType universe)
        {
            var service = _universeFactory(universe);
            return await service.GetSquad();
        }
    }
}
