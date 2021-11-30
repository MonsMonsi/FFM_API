using FFMWeb.Core.API.Exceptions;
using FFMWeb.Core.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    // [Authorize]
    [Route("api/players")]
    [Produces("application/json")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _playersService;

        public PlayersController(IPlayersService service)
        {
            _playersService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers([FromQuery] int league, [FromQuery] int season, [FromQuery] int team, [FromQuery] int page)
        {
            try
            {
                var players = await _playersService.GetPlayersAsync(league, season, team, page);
                return Ok(players);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }
        //public IActionResult GetPlayers([FromQuery] int league, [FromQuery] int season, [FromQuery] int team, [FromQuery] int page)
        //{
        //    var filePath = Path.Combine(_basePath, $"Players_L{league}S{season}T{team}P{page}.json");
        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return NotFound();
        //    }

        //    var json = System.IO.File.ReadAllText(filePath);
        //    var jsonObject = JsonSerializer.Deserialize<object>(json);

        //    return Ok(jsonObject);
        //}
    }
}
