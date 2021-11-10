using System;
using System.Collections.Generic;

namespace FFMWebCore.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string EMail { get; set; }
        public virtual IList<UserTeam> Teams { get; set; } = new List<UserTeam>();
    }
}
