using System.Text.Json.Serialization;

namespace SuperSoccer.Domain.Entities
{
    /// <summary>
    /// SuperSoccer Player entity
    /// </summary>
    public class Player : BaseEntity
    {
        /// <summary>
        /// External Id
        /// </summary>
        public required int ExternalId { get; set; }
        /// <summary>
        /// Player's name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Player's weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Player's height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Player's power. Average between height and weight.
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// Universe from where the player is coming
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required UniverseType Universe { get; set; }

        public double CalculatePower()
        {
            return Math.Round((Height + Weight) / 2, 1);
        }
    }
}
