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
        private readonly string _basePath;

        public TeamsController()
        {
            _basePath = Path.Join(Environment.CurrentDirectory, "JsonFiles", "TeamVenue");
        }

        [HttpGet]
        public IActionResult GetTeams([FromQuery] int league, [FromQuery] int season)
        {
            var filePath = Path.Join(_basePath, $"TeamVenue_L{league}S{season}.json");

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
