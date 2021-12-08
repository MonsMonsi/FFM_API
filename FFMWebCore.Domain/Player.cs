using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FFMWebCore.Domain
{
    public class Birth
    {
        public string Date { get; set; }
        public string Country { get; set; }
        public string Place { get; set; }
    }
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Birth Birth { get; set; }
        public string BirthDate { get; set; }
        public string BirthCountry { get; set; }
        public string BirthPlace { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        // public bool Active { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        [JsonIgnore] // prevents JsonSerializer object cycle error
        public virtual IList<UserTeamSquad> UserTeamSquads { get; set; } = new List<UserTeamSquad>();
    }
}
