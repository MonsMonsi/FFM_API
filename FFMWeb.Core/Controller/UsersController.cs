using FFMWeb.Core.API.Exceptions;
using FFMWeb.Core.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Controller
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetByIdentifierAsync([FromRoute] string identifier)
        {
            try
            {
                var user = await _userService.GetUserByIdentifierAsync(identifier);
                return Ok(user);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }
    }
}
