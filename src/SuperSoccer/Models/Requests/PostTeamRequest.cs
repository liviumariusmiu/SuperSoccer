using SuperSoccer.Domain.Enums;

namespace SuperSoccer.Models.Requests
{
    public class PostTeamRequest
    {
        public required string Name { get; set; }
        public required UniverseType Universe { get; set; }
        public required int NumberOfAttackers { get; set; }
        public required int NumberOfDefenders { get; set; }
    }
}
