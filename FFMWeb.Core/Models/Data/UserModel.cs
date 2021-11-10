using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Models.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string EMail { get; set; }
        public virtual IList<UserTeamModel> Teams { get; set; } = new List<UserTeamModel>();
    }
}
