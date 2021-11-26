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
        private readonly string _basePath;

        public PlayersController()
        {
            _basePath = Path.Join(Environment.CurrentDirectory, "JsonFiles", "Players");
        }

        [HttpGet]
        public IActionResult GetPlayers([FromQuery] int league, [FromQuery] int season, [FromQuery] int team, [FromQuery] int page)
        {
            var filePath = Path.Combine(_basePath, $"Players_L{league}S{season}T{team}P{page}.json");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var json = System.IO.File.ReadAllText(filePath);
            var jsonObject = JsonSerializer.Deserialize<object>(json);

            return Ok(jsonObject);
        }
    }
}
