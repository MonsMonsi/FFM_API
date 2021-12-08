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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeamsAsync()
        {
            try
            {
                var teams = await _teamsService.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }
    }
}
