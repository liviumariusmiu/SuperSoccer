using System.Text.Json.Serialization;

namespace SuperSoccer.Domain.Entities
{
    public class AssignedPlayer : Player
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PlayerType Position { get; set; }
    }
}
