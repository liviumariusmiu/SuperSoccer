using System.Text.Json.Serialization;

namespace SuperSoccer.Domain.Entities
{
    /// <summary>
    /// SuperSoccer Team entity
    /// </summary>
    public class Team : BaseEntity
    {
        /// <summary>
        /// Team Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Universe the team belongs to
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UniverseType Universe { get; set; }

        /// <summary>
        /// List of team players 
        /// </summary>
        public List<AssignedPlayer> Players { get; set; }

        /// <summary>
        /// SoccerTeamPower. Sum of players power.
        /// </summary>
        public double SoccerTeamPower { get; set; }

        public double CalculatePower()
        {
            return Math.Round(Players.Sum(player => player.Power), 1);
        }
        
    }
}
