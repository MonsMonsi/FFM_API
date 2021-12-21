using AutoMapper;
using FFMWeb.Core.API.Models.Data;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public class UserTeamsService : ServiceBase, IUserTeamsService
    {
        public UserTeamsService(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper) : base(context, contextAccessor, mapper)
        { 
        }

        public async void SetAsync(string userTeamData)
        {
            Console.WriteLine(userTeamData);
        }
    }
}
