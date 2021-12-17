using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Models.Data
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string BirthCountry { get; set; }
        public string BirthPlace { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        public int TeamId { get; set; }
        public TeamModel Team { get; set; }
        [JsonIgnore] // prevents JsonSerializer object cycle error
        public virtual IList<UserTeamSquadModel> UserTeamSquads { get; set; } = new List<UserTeamSquadModel>();
    }
}
