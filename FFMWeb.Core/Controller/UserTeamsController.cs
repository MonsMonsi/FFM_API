using FFMWeb.Core.API.Exceptions;
using FFMWeb.Core.API.Models.Data;
using FFMWeb.Core.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Controller
{
    [Route("api/userteams")]
    [Produces("application/json")]
    [ApiController]
    public class UserTeamsController : ControllerBase
    {
        private readonly IUserTeamsService _userTeamsService;

        public UserTeamsController(IUserTeamsService service)
        {
            _userTeamsService = service;
        }

        [HttpPost]
        public async Task<IActionResult> SetUserTeamAsync([FromBody] string userTeamData)
        {
            try
            {
                _userTeamsService.SetUserTeamAsync(userTeamData);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }
    }
}
