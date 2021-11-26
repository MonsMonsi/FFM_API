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
        public int GK1_Id { get; set; }
        public int GK2_Id { get; set; }
        public int DF1_Id { get; set; }
        public int DF2_Id { get; set; }
        public int DF3_Id { get; set; }
        public int DF4_Id { get; set; }
        public int DF5_Id { get; set; }
        public int MF1_Id { get; set; }
        public int MF2_Id { get; set; }
        public int MF3_Id { get; set; }
        public int MF4_Id { get; set; }
        public int MF5_Id { get; set; }
        public int AT1_Id { get; set; }
        public int AT2_Id { get; set; }
        public int AT3_Id { get; set; }
        public int AT4_Id { get; set; }
        public virtual UserTeam UserTeamId { get; set; }
    }
}
