using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FFMWebCore.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        [JsonIgnore]
        public virtual IList<Player> Players { get; set; } = new List<Player>();
    }
}
