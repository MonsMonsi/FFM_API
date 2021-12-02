using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMWebCore.Domain
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
    }
}
