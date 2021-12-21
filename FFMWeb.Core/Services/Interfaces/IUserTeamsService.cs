using FFMWeb.Core.API.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services.Interfaces
{
    public interface IUserTeamsService
    {
        void SetAsync(string userTeamData);
    }
}
