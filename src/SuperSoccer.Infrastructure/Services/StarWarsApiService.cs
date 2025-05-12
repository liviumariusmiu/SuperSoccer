using SharpTrooper.Core;
using System.Text.RegularExpressions;

namespace SuperSoccer.Infrastructure.Services
{
    /// <summary>
    /// StarWars API service that makes requests to https://swapi.dev/ using the updated SharpTrooper thirdparty library.
    /// </summary>
    public class StarWarsApiService : IStarWarsApiService
    {
        private readonly SharpTrooperCore _sharpTrooperCore;
        private readonly Regex swPeopleIdRegex = new("people\\/(?<SWCharId>\\d+)\\/"
                , RegexOptions.Singleline | RegexOptions.Compiled);

        public StarWarsApiService(SharpTrooperCore sharpTrooperCore)
        {
            _sharpTrooperCore = sharpTrooperCore;
        }

        public async Task<Player?> GetPlayerById(int id)
        {
            var swCharacter = await _sharpTrooperCore.GetPeople(id);

            if (swCharacter == null)
                return null;

            return new Player
            {
                Id = Guid.NewGuid(),
                //No ID provided as parameter. Retrieving it from URL.
                ExternalId = int.Parse(swPeopleIdRegex.Match(swCharacter.Url).Groups["SWCharId"].Value),
                Name = swCharacter.Name,
                Weight = swCharacter.Mass,
                Height = swCharacter.Height,
                Power = PlayerPowerCalculator.CalculatePlayerPower(swCharacter.Height, swCharacter.Mass),
                Universe = UniverseType.StarWars
            };
        }

        public async Task<List<Player>> GetSquad()
        {
            var swCharacter = await _sharpTrooperCore.GetAllPeopleAsync();

            //Take 5 random pokemons
            var randomPokemons = swCharacter.Results.TakeRandom(5);

            return randomPokemons.Select(swCharacter => new Player
            {
                Id = Guid.NewGuid(),
                //No ID provided as parameter. Retrieving it from URL.
                ExternalId = int.Parse(swPeopleIdRegex.Match(swCharacter.Url).Groups["SWCharId"].Value),
                Name = swCharacter.Name,
                Weight = swCharacter.Mass,
                Height = swCharacter.Height,
                Power = PlayerPowerCalculator.CalculatePlayerPower(swCharacter.Height, swCharacter.Mass),
                Universe = UniverseType.StarWars
            }).ToList();
        }
    }
}
