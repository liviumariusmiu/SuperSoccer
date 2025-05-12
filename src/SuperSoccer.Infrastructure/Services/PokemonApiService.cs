using PokeApiNet;

namespace SuperSoccer.Infrastructure.Services
{
    /// <summary>
    /// Pokemon API service that makes requests to https://pokeapi.co/ using PokeApiNet Nuget
    /// </summary>
    public class PokemonApiService : IUniverseApiService
    {
        private readonly PokeApiClient _pokeApiClient;

        public PokemonApiService(PokeApiClient pokeApiClient)
        {
            _pokeApiClient = pokeApiClient;
        }

        public async Task<Player?> GetPlayerById(int id)
        {
            var pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(id);

            if (pokemon == null)
                return null;

            return new Player
            {
                Id = Guid.NewGuid(),
                ExternalId = pokemon.Id,
                Name = pokemon.Name,
                Weight = MeasurementConverter.ConvertWeightFromHgToKg(pokemon.Weight),
                Height = MeasurementConverter.ConvertHeightFromDmToCm(pokemon.Height),
                Power = PlayerPowerCalculator.CalculatePlayerPower(MeasurementConverter.ConvertWeightFromHgToKg(pokemon.Weight), MeasurementConverter.ConvertHeightFromDmToCm(pokemon.Height)),
                Universe = UniverseType.Pokemon
            };
        }

        public async Task<List<Player>> GetSquad()
        {
            //For the sake of this exercise I will only use 100 pokemons 
            var pokemonsList = await _pokeApiClient.GetNamedResourcePageAsync<Pokemon>(100, 0);

            //Take 5 random pokemons
            var randomPokemons = pokemonsList.Results.TakeRandom(5);

            //Download the 5 random pokemons
            var pokemons = await _pokeApiClient.GetResourceAsync(randomPokemons);

            return pokemons.Select(poke => new Player {
                Id = Guid.NewGuid(),
                ExternalId = poke.Id,
                Name = poke.Name,
                Weight = MeasurementConverter.ConvertWeightFromHgToKg(poke.Weight),
                Height = MeasurementConverter.ConvertHeightFromDmToCm(poke.Height),
                Power = PlayerPowerCalculator.CalculatePlayerPower(MeasurementConverter.ConvertWeightFromHgToKg(poke.Weight), MeasurementConverter.ConvertHeightFromDmToCm(poke.Height)),
                Universe = UniverseType.Pokemon
            }).ToList();

        }
    }
}
