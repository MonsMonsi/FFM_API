using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Models.Data
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int LeagueId { get; set; }
        public virtual LeagueModel League { get; set; }
        [JsonIgnore]
        public virtual IList<PlayerModel> Players { get; set; } = new List<PlayerModel>();
    }
}
