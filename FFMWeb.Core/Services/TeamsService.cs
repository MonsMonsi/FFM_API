using AutoMapper;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using FFMWebCore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private readonly FootballContext _context = new();

        public TeamsService(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper) : base(context, contextAccessor, mapper)
        {
            _basePath = Path.Join(Environment.CurrentDirectory, "JsonFiles", "TeamVenue");
        }

        public async Task<Team[]> GetAllTeamsAsync()
        {
            var teamsFromDb = await _context.Teams.Include(t => t.League).ToArrayAsync();

            return teamsFromDb;
        }
    }
}
