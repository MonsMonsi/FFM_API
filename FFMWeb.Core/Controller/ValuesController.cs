using FFMWeb.Core.API.Models;
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
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _service;

        public ValuesController(IValuesService valuesService)
        {
            _service = valuesService;
        }

        [HttpGet]
        public async Task<CalculationResponseModel> CalculateAsync([FromQuery] CalculationRequestModel model)
        {
            return await _service.CalculateAsync(model);
        }
    }
}
