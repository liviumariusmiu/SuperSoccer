using System.Collections.Generic;

namespace SharpTrooper.Entities
{
    /// <summary>
    /// A person within the Star Wars universe
    /// </summary>
    public class People : SharpEntity
    {
        /// <summary>
        /// People entity identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// An array of vehicle resources that this person has piloted
        /// </summary>
        public List<string> Vehicles { get; set; }

        /// <summary>
        /// The gender of this person (if known).
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The url of this resource
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The height of this person in meters.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The hair color of this person.
        /// </summary>
        public string Hair_color { get; set; }

        /// <summary>
        /// The skin color of this person.
        /// </summary>
        public string Skin_color { get; set; }

        /// <summary>
        /// An array of starship resources that this person has piloted
        /// </summary>
        public List<string> Starships { get; set; }

        /// <summary>
        /// The name of this person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An array of urls of film resources that this person has been in.
        /// </summary>
        public List<string> Films { get; set; }

        /// <summary>
        /// The birth year of this person. BBY (Before the Battle of Yavin) or ABY (After the Battle of Yavin).
        /// </summary>
        public string Birth_year { get; set; }

        /// <summary>
        /// The url of the planet resource that this person was born on.
        /// </summary>
        public string Homeworld { get; set; }

        /// <summary>
        /// The url of the species resource that this person is.
        /// </summary>
        public List<string> Species { get; set; }

        /// <summary>
        /// The eye color of this person.
        /// </summary>
        public string Eye_color { get; set; }

        /// <summary>
        /// The mass of this person in kilograms.
        /// </summary>
        public double Mass { get; set; }

    }
}