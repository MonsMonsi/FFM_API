using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Models.Data
{
    public class LeagueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Logo { get; set; }
        public string Flag { get; set; }
        [JsonIgnore]
        public virtual IList<TeamModel> Teams { get; set; } = new List<TeamModel>();
    }
}
