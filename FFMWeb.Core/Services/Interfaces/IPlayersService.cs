using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services.Interfaces
{
    public interface IPlayersService
    {
        Task<object> GetPlayersAsync(int league, int season, int team, int page);
    }
}
