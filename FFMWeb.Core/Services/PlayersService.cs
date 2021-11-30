using AutoMapper;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public class PlayersService: ServiceBase, IPlayersService
    {
        private readonly string _basePath;
        public PlayersService(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper): base(context, contextAccessor, mapper)
        {
            _basePath = Path.Join(Environment.CurrentDirectory, "JsonFiles", "Players");
        }

        public async Task<object> GetPlayersAsync(int league, int season, int team, int page)
        {
            var filePath = Path.Combine(_basePath, $"Players_L{league}S{season}T{team}P{page}.json");
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
