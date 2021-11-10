using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Models.Data
{
    public class SeasonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<UserTeamModel> Teams { get; set; } = new List<UserTeamModel>();
    }
}
