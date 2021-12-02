using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMWebCore.Domain
{
    public class UserTeamSquad
    {
        public int Id { get; set; }
        public int UserTeamId { get; set; }
        public virtual UserTeam UserTeam { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
