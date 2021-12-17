using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Models.Data
{
    public class UserTeamSquadModel
    {
        public int Id { get; set; }
        public int UserTeamId { get; set; }
        public virtual UserTeamModel UserTeam { get; set; }
        public int PlayerId { get; set; }
        public virtual PlayerModel Player { get; set; }
    }
}
