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
        public async Task<IActionResult> GetByLeagueAsync([FromQuery] int league)
        {
            try
            {
                //musste Config.json in FFMWebCore Ordner kopieren !?
                var players = await _playersService.GetByLeagueAsync(league);
                return Ok(players);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var player = await _playersService.GetByIdAsync(id);
                return Ok(player);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }
    }
}
