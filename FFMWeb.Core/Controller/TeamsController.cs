using FFMWeb.Core.API.Exceptions;
using FFMWeb.Core.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Controller
{
    [Route("api/teams")]
    [Produces("application/json")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;

        public TeamsController(ITeamsService service)
        {
            _teamsService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams([FromQuery] int league, [FromQuery] int season)
        {
            try
            {
                var teams = await _teamsService.GetTeamsAsync(league, season);
                return Ok(teams);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
            //var filePath = Path.Join(_basePath, $"TeamVenue_L{league}S{season}.json");

            //if (!System.IO.File.Exists(filePath))
            //{
            //    return NotFound();
            //}

            //var json = System.IO.File.ReadAllText(filePath);
            //var jsonObject = JsonSerializer.Deserialize<object>(json);

            //return Ok(jsonObject);
        }
    }
}
