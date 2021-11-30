using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services.Interfaces
{
    public interface ITeamsService
    {
        Task<object> GetTeamsAsync(int league, int season);
    }
}
