using AutoMapper;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using FFMWebCore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly FootballContext _context = new();
        public PlayersService(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper): base(context, contextAccessor, mapper)
        {
            _basePath = Path.Join(Environment.CurrentDirectory, "JsonFiles", "Players");
        }

        public async Task<Player[]> GetPlayerByIdAsync(int id)
        {
            var playerFromDb = await _context.Players.Include(p => p.Team).ThenInclude(t => t.League).Where(p=> p.Id == id).ToArrayAsync();

            return playerFromDb;
        }

        public async Task<Player[]> GetPlayersByLeagueAsync(int leagueId)
        {
            var playersFromDb =  await _context.Players.Include(p => p.Team).ThenInclude(t => t.League).Where(p => p.Team.League.Id == leagueId).ToArrayAsync();

            return playersFromDb;
        }
    }
}
