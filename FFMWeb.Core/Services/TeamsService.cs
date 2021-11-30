using AutoMapper;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public class TeamsService : ServiceBase, ITeamsService
    {
        private readonly string _basePath;

        public TeamsService(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper) : base(context, contextAccessor, mapper)
        {
            _basePath = Path.Join(Environment.CurrentDirectory, "JsonFiles", "TeamVenue");
        }
        public async Task<object> GetTeamsAsync(int league, int season)
        {
            var filePath = Path.Join(_basePath, $"TeamVenue_L{league}S{season}.json");

            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

            var json = System.IO.File.ReadAllText(filePath);
            var jsonObject = JsonSerializer.Deserialize<object>(json);

            return jsonObject;
        }
    }
}
